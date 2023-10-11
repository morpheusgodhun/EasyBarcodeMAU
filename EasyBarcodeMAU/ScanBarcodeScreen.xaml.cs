using ZXing;
using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;
using ZXing.QrCode.Internal;

namespace EasyBarcodeMAU;
public partial class ScanBarcodeScreen : ContentPage {

    #region Variables

    private ProductItemBase selectedItem;
    private ReadBaseModel viewModel;

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

    private ObservableCollection<string> scannedBarcodes = new ObservableCollection<string>();


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

    private void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args) {
        MainThread.BeginInvokeOnMainThread(() => {
            if (args.Result.Length > 0) {
                for (int i = 0; i < args.Result.Length; i++) {
                    if (viewModel.ReadedCount >= viewModel.RequiredCount) {
                        break;
                    }

                    var format = args.Result[i].BarcodeFormat;
                    var text = args.Result[i].Text;
                    barcodeResult.Text = $"{text}";
                    viewModel.ReadedCount++;
                    scannedBarcodes.Add(text);
                }
            }
            else {
                barcodeResult.Text = "Barkod bulunamadý.";
            }
        });
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

    public ScanBarcodeScreen(ProductItemBase selectedItem) : this() {
        this.selectedItem = selectedItem;
        viewModel.SelectedProduct = selectedItem?.UrunCins;
        this.viewModel.RequiredCount = selectedItem.RequiredCount;
        this.viewModel.DepoKonum = selectedItem.DepoKonum;
    }

    private void Vazgec_Clicked(object sender, EventArgs e) {
        Navigation.PushAsync(new ProductListPage());
    }

    private void Onayla_Clicked(object sender, EventArgs e) {
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
            boxView1.Color = Color.FromRgb(255, 255, 255);
            boxView2.Color = Color.FromRgb(255, 255, 255);
            



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
            boxView1.Color = Color.FromRgb(255, 255, 255);
            boxView2.Color = Color.FromRgb(255, 255, 255);

        }
    }
    #endregion
}
