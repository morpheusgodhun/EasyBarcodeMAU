using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU;
public partial class ScanBarcodeScreen : ContentPage {

    #region Variables

    private ProductItemBase _selectedItem;
    private ReadBaseModel viewModel;
    private bool isFocusing = false;
    private int focusDelayMilliseconds = 1500;

    #endregion

    #region InitModel

    private void ClearScannedBarcodes() {
        scannedBarcodes.Clear();
    }


    public ScanBarcodeScreen() {
        InitializeComponent();
        viewModel = new ReadBaseModel();
        BindingContext = viewModel;
        barcodeListView.ItemsSource = scannedBarcodes;
    }

    #endregion

 
    #region Properties

    private int _count;
    public int Count {
        get { return _count; }
        set {

            if (_count != value) {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }
    #endregion

    #region Methods

    public class BarcodeItem
    {
        public string Barcode { get; set; }
        public int Count { get; set; }
    }

    private ObservableCollection<(string Barcode, int Count)> scannedBarcodes = new();

    private async void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
    {
        if (!isFocusing)
        {
            isFocusing = true;
            MainThread.BeginInvokeOnMainThread( () => {

                if (args.Result.Length > 0)
                {
                    for (int i = 0; i < args.Result.Length; i++)
                    {
                        var format = args.Result[i].BarcodeFormat;
                        var text = args.Result[i].Text;
                        barcodeResult.Text = $"{text}";
                        viewModel.ReadedCount++;

                        var existingItem = scannedBarcodes.FirstOrDefault(item => item.Barcode == text);
                        if (existingItem != default)
                        {
                            scannedBarcodes.Remove(existingItem);
                            scannedBarcodes.Add((text, existingItem.Count + 1));
                        }
                        else
                        {
                            scannedBarcodes.Add((text, 1));
                        } 

                        Vibration.Vibrate();
                    }
                }
                else
                {
                    barcodeResult.Text = "Barkod bulunamadý.";
                }
            });

            await Task.Delay(focusDelayMilliseconds);
            isFocusing = false;
        }
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e) {
        if (cameraView.Cameras.Count > 0) {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () => {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    public ScanBarcodeScreen(ProductItemBase _selectedItem) : this() {
        this._selectedItem = _selectedItem;
        viewModel.SelectedProduct = _selectedItem?.UrunCins;
        this.viewModel.RequiredCount = _selectedItem.RequiredCount;
        this.viewModel.DepoKonum = _selectedItem.DepoKonum;
    }

    private async void Vazgec_Clicked(object sender, EventArgs e) {
        await Navigation.PopAsync();
    }

    private async void Onayla_Clicked(object sender, EventArgs e) {

        if (viewModel.ReadedCount == viewModel.RequiredCount) {

            barcodeResult.Text = "Kayýt Onaylandý, Hedeflenen Stok Adedi Sayýmýna Ulaþýldý.";
            this.BackgroundColor = Color.FromRgb(51, 153, 255);
            label1.TextColor = Color.FromRgb(255, 255, 255);
            label2.TextColor = Color.FromRgb(255, 255, 255);
            label3.TextColor = Color.FromRgb(255, 255, 255);
            label4.TextColor = Color.FromRgb(255, 255, 255);
            label5.TextColor = Color.FromRgb(255, 255, 255);
            label6.TextColor = Color.FromRgb(255, 255, 255);
            label7.TextColor = Color.FromRgb(255, 255, 255);
            label8.TextColor = Color.FromRgb(255, 255, 255);
            boxView1.Color =   Color.FromRgb(255, 255, 255);
            boxView2.Color =   Color.FromRgb(255, 255, 255);
            await Navigation.PushAsync(new EditItemPage(_selectedItem, viewModel.ReadedCount));


        }
        else {
            barcodeResult.Text = "! Hatalý Sayým Gerçekleþtirdiniz";
            this.BackgroundColor = Color.FromRgba(255, 0, 0, 255);
            label1.TextColor = Color.FromRgb(255, 255, 255);
            label2.TextColor = Color.FromRgb(255, 255, 255);
            label3.TextColor = Color.FromRgb(255, 255, 255);
            label4.TextColor = Color.FromRgb(255, 255, 255);
            label5.TextColor = Color.FromRgb(255, 255, 255);
            label6.TextColor = Color.FromRgb(255, 255, 255);
            label7.TextColor = Color.FromRgb(255, 255, 255);
            label8.TextColor = Color.FromRgb(255, 255, 255);
            boxView1.Color   = Color.FromRgb(255, 255, 255);
            boxView2.Color   = Color.FromRgb(255, 255, 255);

        }                            
       
    }
    #endregion
}
