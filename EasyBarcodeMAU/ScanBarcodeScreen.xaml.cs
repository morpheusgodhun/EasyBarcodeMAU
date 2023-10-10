using ZXing;
using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
    public partial class ScanBarcodeScreen : ContentPage {

        #region Variables

        private ProductItemBase selectedItem;
        private ReadBaseModel viewModel;

        #endregion

        #region InitModel

        public ScanBarcodeScreen() {
            InitializeComponent();
            viewModel = new ReadBaseModel();
            BindingContext = viewModel;
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

       

        private void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args) {
            MainThread.BeginInvokeOnMainThread(() => {
                if (args.Result.Length > 0) {
                    var format = args.Result[0].BarcodeFormat;
                    var text = args.Result[0].Text;
                    barcodeResult.Text = $"{text}";
                    viewModel.ReadedCount++;
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
            viewModel.SelectedProduct = selectedItem?.MusteriAd + ", " + "Konum:" + selectedItem?.DepoKonum;
            this.viewModel.RequiredCount = selectedItem.RequiredCount;
        }    
    #endregion

}
