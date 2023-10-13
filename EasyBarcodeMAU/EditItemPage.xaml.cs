using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU {
    public partial class EditItemPage : ContentPage {
        private ProductItemBase _selectedItem;
        private ReadBaseModel viewModel;
        private int _readedCount;

        public EditItemPage(ProductItemBase selectedItem, int readedCount) {
            InitializeComponent();
            _selectedItem = selectedItem;
            _readedCount = readedCount;
            viewModel = new ReadBaseModel();
            viewModel.ReadedCount = _readedCount;
            BindingContext = viewModel;
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
