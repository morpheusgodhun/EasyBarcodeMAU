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
    private string lastScannedBarcode = "";

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
        viewModel.SelectedProduct = selectedItem?.ProductType;
        viewModel.RequiredCount = selectedItem.RequiredCount;
        viewModel.WareHouseLocation = selectedItem.WareHouseLocation;
    }

    #endregion

    #region Methods

    private static bool IsDigitsOnly(string str) {
        return str.All(char.IsDigit);
    }

    protected override void OnDisappearing() {
        base.OnDisappearing();

        loadingIndicator.IsVisible = false;
        loadingIndicator.IsRunning = false;
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
                    if (text != lastScannedBarcode) {
                        textTotal.TextColor = Color.FromRgb(175, 255, 0);
                        label4.TextColor = Color.FromRgb(175, 255, 0);
                        labelTotalCount.TextColor = Color.FromRgb(175, 255, 0);
                    }

                    if (IsBarcodeInDatabase(text)) {
                        if (!IsBarcodeCountValid(text)) {
                            textTotal.TextColor = Color.FromRgb(255, 0, 0);
                            label4.TextColor = Color.FromRgb(255, 0, 0);
                            labelTotalCount.TextColor = Color.FromRgb(255, 0, 0);
                            continue;
                        }

                        viewModel.ReadedCount++;                  
                        var existingItem = scannedBarcodes.FirstOrDefault(item => item.Barcode == text);
                        if (existingItem != default) {
                            existingItem.Count++;
                            Vibration.Vibrate();
                        }
                        else {
                            scannedBarcodes.Add(new ReadBaseModel { Barcode = text, Count = 1 });
                        }
                    }
                    else {
                        textTotal.TextColor = Color.FromRgb(255, 0, 0);
                        label4.TextColor = Color.FromRgb(255, 0, 0);
                        labelTotalCount.TextColor = Color.FromRgb(255, 0, 0);
                    }

                    viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
                    lastScannedBarcode = text;
                }
            });
            await Task.Delay(focusDelayMilliseconds);
            isFocusing = false;
        }
    }


    private bool IsBarcodeInDatabase(string barcode) {
        var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == _selectedItem.Id);
        if (product == null) return false;

        long barcodeAsLong;
        if (long.TryParse(barcode, out barcodeAsLong)) {
            return product.ScannedBarcodes.Contains(barcodeAsLong);
        }
        return false;
    }

    private void EkleButton_Clicked(object sender, EventArgs e) {
        string barcode = new string(barcodeEntry.Text.Where(char.IsDigit).ToArray());
        if (!string.IsNullOrWhiteSpace(barcode)) {
            if (IsBarcodeInDatabase(barcode)) {
                if (IsBarcodeCountValid(barcode)) {
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
                    label4.TextColor = Color.FromRgb(255, 0, 0);
                    textTotal.TextColor = Color.FromRgb(255, 0, 0);
                    labelTotalCount.TextColor = Color.FromRgb(255, 0, 0);
                }
            }
            else {
                label4.TextColor = Color.FromRgb(255, 0, 0);
                textTotal.TextColor = Color.FromRgb(255, 0, 0);
                labelTotalCount.TextColor = Color.FromRgb(255, 0, 0);
            }
        }
        else {
        }
    }

    private bool IsBarcodeCountValid(string barcode) {
        var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == _selectedItem.Id);
        if (product == null) return true;

        long barcodeAsLong;
        if (long.TryParse(barcode, out barcodeAsLong)) {
            int requiredCount = product.ScannedBarcodes.Count(b => b == barcodeAsLong);
            var existingItem = scannedBarcodes.FirstOrDefault(item => item.Barcode == barcode);
            if (existingItem != null && existingItem.Count == requiredCount) {
                return false;
            }
        }
        return true;
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
        if (product == null) return true;

        var productBarcodeSet = new HashSet<long>(product.ScannedBarcodes);

        foreach (var scanned in scannedBarcodes) {
            long barcodeAsLong;
            if (long.TryParse(scanned.Barcode, out barcodeAsLong)) {
                if (!productBarcodeSet.Contains(barcodeAsLong)) {
                    continue;
                }
                int requiredCount = product.ScannedBarcodes.Count(b => b == barcodeAsLong);
                if (scanned.Count > requiredCount) {
                    barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
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
        label1.TextColor = Color.FromRgb(255, 255, 255);
        label2.TextColor = Color.FromRgb(255, 255, 255);
        label4.TextColor = Color.FromRgb(255, 255, 255);
        label7.TextColor = Color.FromRgb(255, 255, 255);
        label8.TextColor = Color.FromRgb(255, 255, 255);
        textTotal.TextColor = Color.FromRgb(255, 255, 255);
        labelTotalCount.TextColor = Color.FromRgb(255, 255, 255);
        boxView1.Color = Color.FromRgb(255, 255, 255);
        boxView2.Color = Color.FromRgb(255, 255, 255);

        bool shouldNavigate = true;

        if (!AreBarcodeCountsValid(productId)) {
            barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
            shouldNavigate = false;
            RemoveExcessBarcodes(productId);
        }
        else if (!AreBarcodesValid(productId)) {
            barcodeListView.BackgroundColor = Color.FromRgb(255, 0, 0);
            shouldNavigate = false;
        }

        if (shouldNavigate) {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;
            await Task.Delay(2000);
            await Navigation.PushAsync(new OutputEditItemPage(_selectedItem, viewModel.TotalCount, _selectedItem.ProductType, _selectedItem.CustomerName, scannedBarcodes));
            await cameraView.StopCameraAsync();
        }
    }

    private void RemoveExcessBarcodes(int productId) {
        var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == productId);
        if (product == null) return;

        var productBarcodeSet = new HashSet<long>(product.ScannedBarcodes);

        var excessBarcodes = scannedBarcodes.Where(scanned => {
            long barcodeAsLong;
            if (long.TryParse(scanned.Barcode, out barcodeAsLong)) {
                return productBarcodeSet.Contains(barcodeAsLong) && scanned.Count > product.ScannedBarcodes.Count(b => b == barcodeAsLong);
            }
            return false;
        }).ToList();

        foreach (var excessBarcode in excessBarcodes) {
            scannedBarcodes.Remove(excessBarcode);
        }
    }

    private void Onayla_Clicked(object sender, EventArgs e) {
        int productId = _selectedItem.Id;
        HandleOnaylaClick(productId);
    }
    #endregion
}
