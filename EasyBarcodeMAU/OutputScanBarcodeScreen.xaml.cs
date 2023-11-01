using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU;
public partial class OutputScanBarcodeScreen : ContentPage {
    #region Variables

    private OutputReadBaseModel viewModel;
    private ProductItemBase _selectedItem;
    private bool isFocusing = false;
    private int focusDelayMilliseconds = 1470;
    private ObservableCollection<ReadBaseModel> scannedBarcodes = new();
    string newText;

    #endregion

    #region InitModel

    public OutputScanBarcodeScreen() {
        InitializeComponent();
        viewModel = new OutputReadBaseModel();
        BindingContext = viewModel;
        barcodeListView.ItemsSource = scannedBarcodes;
    }

    public OutputScanBarcodeScreen(ProductItemBase selectedItem) : this() {
        _selectedItem = selectedItem;
        viewModel.SelectedProduct = selectedItem?.UrunCins;
        viewModel.RequiredCount = selectedItem.RequiredCount;
        viewModel.DepoKonum = selectedItem.DepoKonum;
    }

    #endregion

    #region Methods

    private static bool IsDigitsOnly(string str) {
        return str.All(char.IsDigit);
    }

    public ObservableCollection<ReadBaseModel> ScannedBarcodes {
        get { return scannedBarcodes; }
        set {
            if (scannedBarcodes != value) {
                scannedBarcodes = value;
                OnPropertyChanged(nameof(ScannedBarcodes));
            }
        }
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await cameraView.StartCameraAsync();
        viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
    }
    private void BarcodeEntry_TextChanged(object sender, TextChangedEventArgs e) {
        newText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());
        barcodeEntry.Text = newText;
    }

    private async void BarcodeDetected(object sender, BarcodeEventArgs args) {
        if (!isFocusing) {
            isFocusing = true;
            MainThread.BeginInvokeOnMainThread(() => {
                foreach (var result in args.Result) {
                    var text = result.Text;
                    viewModel.ReadedCount++;
                    Vibration.Vibrate();
                    var existingItem = scannedBarcodes.FirstOrDefault(item => item.Barcode == text);
                    if (existingItem != default) {
                        existingItem.Count++;
                    }
                    else {
                        scannedBarcodes.Add(new ReadBaseModel { Barcode = text, Count = 1 });
                    }
                    viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
                }
            });
            await Task.Delay(focusDelayMilliseconds);
            isFocusing = false;
        }
    }

    private void EkleButton_Clicked(object sender, EventArgs e) {
        string barcode = new string(barcodeEntry.Text.Where(char.IsDigit).ToArray());

        if (!string.IsNullOrWhiteSpace(barcode)) {
            var existingItem = scannedBarcodes.FirstOrDefault(item => item.Barcode == barcode);

            if (existingItem != null) {
                existingItem.Count++;
                Vibration.Vibrate();
            }
            else {
                scannedBarcodes.Add(new ReadBaseModel { Barcode = barcode, Count = 1 });
            }

            barcodeEntry.Text = string.Empty;
            viewModel.ReadedCount++;
            viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
        }
        else {
            DisplayAlert("Hata", "Lütfen yalnýzca rakam içeren bir deðer girin.", "Tamam");
        }
    }

    private void Camerasloaded(object sender, EventArgs e) {
        if (cameraView.Cameras.Any()) {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () => {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }
    public bool AreBarcodesValid(int productId) {
        var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == productId);
        if (product == null) return false;

        return scannedBarcodes.Any(scannedBarcode => product.ScannedBarcodes.Contains(Convert.ToInt64(scannedBarcode.Barcode)));
    }

    public bool AreBarcodeCountsValid(int productId) {
        var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == productId);
        if (product == null) return false;

        var productBarcodeSet = new HashSet<long>(product.ScannedBarcodes);

        foreach (var scanned in scannedBarcodes) {
            long barcodeAsLong;
            if (long.TryParse(scanned.Barcode, out barcodeAsLong)) {
                if (!productBarcodeSet.Contains(barcodeAsLong)) {
                    continue; // Burasý olmayan bir barkodun SAYISINA BAKMA DEVAM ET, AÞAÐISI OLAN BARKODLARIN MAKSÝMUMUM ADEDÝNÝ KONTROL ET
                }
                int requiredCount = product.ScannedBarcodes.Count(b => b == barcodeAsLong);
                if (scanned.Count != requiredCount) {
                    barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
                    DisplayAlert("Hata", "Tanýmlý MAKSÝMUM barkod adedini aþtýnýz", "Tamam");
                    return false;
                }
            }
        }
        return true;
    }

    private async void Vazgec_Clicked(object sender, EventArgs e) {
        await Navigation.PopAsync();
    }
    private bool shouldNavigate = true;

    private async void HandleOnaylaClick(int productId) {
        this.BackgroundColor = Color.FromRgb(51, 153, 255);
        label1.TextColor = Color.FromRgb(255, 255, 255);
        label2.TextColor = Color.FromRgb(255, 255, 255);
        label4.TextColor = Color.FromRgb(255, 255, 255);
        label7.TextColor = Color.FromRgb(255, 255, 255);
        label8.TextColor = Color.FromRgb(255, 255, 255);
        textTotal.TextColor = Color.FromRgb(255, 255, 255);
        labelTotalCount.TextColor = Color.FromRgb(255, 255, 255);
        boxView1.Color = Color.FromRgb(255, 255, 255);
        boxView2.Color = Color.FromRgb(255, 255, 255);

        if (!AreBarcodeCountsValid(productId)) {
            barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
            await DisplayAlert("Adet Hatasý", "Hedeflenen Barkod Adedini aþtýnýz..", "Tamam");
            shouldNavigate = false; //yönlendirmeyi burda iptal et
        }
        else if (!AreBarcodesValid(productId)) {
            barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
            await DisplayAlert("Hata", "Taradýðýnýz barkodlar veya miktarlar ürünle eþleþmiyor.", "Tamam");
            shouldNavigate = false; //yönlendirmeyi burda iptal et 
        }

        if (shouldNavigate) {
            await Navigation.PushAsync(new EditItemPage(_selectedItem, viewModel.TotalCount, _selectedItem.UrunCins, _selectedItem.MusteriAd, scannedBarcodes));
            await cameraView.StopCameraAsync();
        }
    }
    private void Onayla_Clicked(object sender, EventArgs e) {
        int productId = _selectedItem.Id;
        HandleOnaylaClick(productId);
    }
    #endregion
}
