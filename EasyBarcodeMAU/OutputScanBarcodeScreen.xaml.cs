using Camera.MAUI.ZXingHelper;
using EasyBarcodeMAU.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace EasyBarcodeMAU {
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
        //!!!!!!!!!!!
        //BarcodeModel olu�turuldu okutulan, yaz�lan barkodlar tek yerde tutulacak �ekilde
        //YAPMAK �STED���M �R�N G�R��� EKRANINDA OKUTULAN BARKODLARI SAKLAYIP
        //�R�N �IKI�INDA DA BU BARKODLARI OKUTMAK �D�, �R�N G�R���NDEN D�REKT �R�N �IKI�A Y�NLEND�R�P BUNU TEST ETT�M,
        //�ALI�IYOR ANCAK BU YAPIYA GE��LEMED� SEBEB� ARADA 4 SAYFA GE���� OLDU�U ���N HER SAYFADA BU VER�LER� SAKLAMAYA �ALI�MAK ���N METHODLARIN
        //ONAPPERING'INDE BU VER�LER� SAKLAMAK ANCAK D�NAM�K OLARAK DE���T��� ���N HER SINIFTA BU VER�LER SAKLANSA B�LE UYGULAMA KAPATILANA KADAR SAKLANIYOR,
        //FARKLI B�R BARKOD OKUTULMAK �STEND���NDE DE BUNLAR KALDI�I ���N BU D���NCE VER� TABANINDA B�LG� SAKLAYARAK YAPILAB�L�R !!!!!!
        //!!!!!!
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
                }
                else {
                    scannedBarcodes.Add(new ReadBaseModel { Barcode = barcode, Count = 1 });
                }

                barcodeEntry.Text = string.Empty;
                viewModel.ReadedCount++;
                viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
            }
            else {
                DisplayAlert("Hata", "L�tfen yaln�zca rakam i�eren bir de�er girin.", "Tamam");
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

        public bool AreBarcodesValidForProduct(int productId) {
            var product = OutPutProductModel.Instance.ProductItems.FirstOrDefault(p => p.Id == productId);
            return product != null && scannedBarcodes.All(barcodeModel => product.ScannedBarcodes.Contains(Convert.ToInt64(barcodeModel.Barcode)));
        }

        private async void Vazgec_Clicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }
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

            if (AreBarcodesValidForProduct(productId)) {
                await Navigation.PushAsync(new EditItemPage(_selectedItem, viewModel.TotalCount, _selectedItem.UrunCins, _selectedItem.MusteriAd, scannedBarcodes));
                await cameraView.StopCameraAsync();
            }
            else {
                await DisplayAlert("Hata", "Tarad���n�z barkodlar �r�nle e�le�miyor.", "Tamam");
            }
        }
        private void Onayla_Clicked(object sender, EventArgs e) {
            int productId = _selectedItem.Id;
            HandleOnaylaClick(productId);
        }
    }
    #endregion
}
