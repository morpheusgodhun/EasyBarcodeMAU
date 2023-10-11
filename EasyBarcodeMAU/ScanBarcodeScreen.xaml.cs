using ZXing;
using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU;
public partial class ScanBarcodeScreen : ContentPage {

    #region Variables

    private ProductItemBase selectedItem;
    private ReadBaseModel viewModel;

    #endregion

    #region InitModel

    private void ClearScannedBarcodes()
    {
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
            if (args.Result.Length > 0)
            {
                var format = args.Result[0].BarcodeFormat;
                var text = args.Result[0].Text;
                barcodeResult.Text = $"{text}";
                viewModel.ReadedCount++;

                // Add the scanned barcode to the list
                scannedBarcodes.Add(text);
            }
            else
            {
                barcodeResult.Text = "Barkod bulunamad�.";
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
        viewModel.SelectedProduct = selectedItem?.UrunCins;/*+ ", " + "Konum:" + selectedItem?.DepoKonum;*/
        this.viewModel.RequiredCount = selectedItem.RequiredCount;
        this.viewModel.DepoKonum = selectedItem.DepoKonum;
    }


    #endregion

    private void Vazgec_Clicked(object sender, EventArgs e) {
        Navigation.PushAsync(new ProductListPage());
    }
}
