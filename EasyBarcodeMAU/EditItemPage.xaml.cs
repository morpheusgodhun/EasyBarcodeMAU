using System.Collections.ObjectModel;
using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
    public partial class EditItemPage : ContentPage {
        private int _readedCount;
        private int _count;
        private ProductItemBase _selectedItem;
        private ReadBaseModel viewModel;
        private ObservableCollection<ReadBaseModel> scannedBarcodes;

        public EditItemPage(ProductItemBase selectedItem, int readedCount, ObservableCollection<ReadBaseModel> scannedBarcodes) {
            InitializeComponent();
            _selectedItem = selectedItem;
            _readedCount = readedCount;
            this.scannedBarcodes = scannedBarcodes;
            viewModel = new ReadBaseModel();
            viewModel.ReadedCount = _readedCount;
            viewModel.Count = _count;
            BindingContext = viewModel;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            barcodeListView.ItemsSource = scannedBarcodes;
        }

        private void ArtirButton_Clicked() {
            _count++;
        }

        private void AzaltButton_Clicked() {           
             _count--;          
        }
    }