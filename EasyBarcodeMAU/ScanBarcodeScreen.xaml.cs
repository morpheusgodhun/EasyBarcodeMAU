using ZXing;
using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU {
    public partial class ScanBarcodeScreen : ContentPage {
        private ProductItemBase selectedItem;
        private ReadBaseModel viewModel; // viewModel burada tanımlanır

        public ScanBarcodeScreen() {
            InitializeComponent();
            viewModel = new ReadBaseModel(); // viewModel burada oluşturulur
            BindingContext = viewModel;
        }

        public ScanBarcodeScreen(ProductItemBase selectedItem) : this() {
            this.selectedItem = selectedItem;
            viewModel.SelectedProduct = selectedItem?.MusteriAd + ", " + "Konum:" + selectedItem?.DepoKonum;
        }

        private void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args) {
            MainThread.BeginInvokeOnMainThread(() => {
                if (args.Result.Length > 0) {
                    var format = args.Result[0].BarcodeFormat;
                    var text = args.Result[0].Text;
                    barcodeResult.Text = $"{format}: {text}";
                    viewModel.ReadedCount++;
                }
                else {
                    barcodeResult.Text = "Barkod bulunamadı.";
                }
            });
        }

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

        private void cameraView_CamerasLoaded(object sender, EventArgs e) {
            if (cameraView.Cameras.Count > 0) {
                cameraView.Camera = cameraView.Cameras.First();
                MainThread.BeginInvokeOnMainThread(async () => {
                    await cameraView.StopCameraAsync();
                    await cameraView.StartCameraAsync();
                });
            }
        }
    }
}
