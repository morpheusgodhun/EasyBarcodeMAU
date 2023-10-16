using System.Collections.ObjectModel;
using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU {
    public partial class EditItemPage : ContentPage {
        private int _readedCount;
        private ProductItemBase _selectedItem;
        private ReadBaseModel viewModel;
        private ObservableCollection<BarcodeItem> scannedBarcodes;

        public EditItemPage(ProductItemBase selectedItem, int readedCount, ObservableCollection<BarcodeItem> scannedBarcodes) {
            InitializeComponent();
            _selectedItem = selectedItem;
            _readedCount = readedCount;
            this.scannedBarcodes = scannedBarcodes;
            viewModel = new ReadBaseModel();
            viewModel.ReadedCount = _readedCount;
            BindingContext = this;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            barcodeListView.ItemsSource = scannedBarcodes;
        }

        private void ArtirButton_Clicked(object sender, EventArgs e) {
            viewModel.ReadedCount++;
        }

        private void AzaltButton_Clicked(object sender, EventArgs e) {
            if (viewModel.ReadedCount > 0) {
                viewModel.ReadedCount--;
            }
        }
    }
}
