using System.Collections.ObjectModel;
using System.Windows.Input;

using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU
{
    public partial class ProductListPage : ContentPage
    {
        private ProductItemBase selectedItem;
        public ProductListPage()
        {
            InitializeComponent();
            BindingContext = new ProductModel();
        }

        private async void Frame_Tapped(object sender, EventArgs e) {
            if (sender is Frame tappedFrame) {
                if (tappedFrame.BindingContext is ProductItemBase itemBase) {
                    selectedItem = itemBase; 

                    var scanPage = new ScanBarcodeScreen(selectedItem);
                    await Navigation.PushAsync(scanPage);
                }
            }
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            var scanPage = new ScanBarcodeScreen();
            Navigation.PushAsync(scanPage);
        }
 
    }
}
