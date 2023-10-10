using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
    public partial class ProductListPage : ContentPage {

        #region Variables
        private ProductItemBase selectedItem;
    #endregion

  


    #region InitModel
    public ProductListPage() {
            InitializeComponent();
            BindingContext = new ProductModel();
        }

        #endregion

        #region Methods

        private async void Frame_Tapped(object sender, EventArgs e)
{
    if (sender is Frame tappedFrame)
    {
        if (tappedFrame.BindingContext is ProductItemBase itemBase)
        {
            if (selectedItem != null)
            {
                    tappedFrame.BorderColor = Color.FromRgb(128, 128, 128);  
                                                                            
                }

                var greenColor = Color.FromRgba(0, 255, 0, 255); 
                tappedFrame.BorderColor = greenColor;   

            selectedItem = itemBase;

            var scanPage = new ScanBarcodeScreen(selectedItem);
            await Navigation.PushAsync(scanPage);
        }
    }
}


        private void OnConfirmButtonClicked(object sender, EventArgs e) {
            var scanPage = new ScanBarcodeScreen();
            Navigation.PushAsync(scanPage);
        }    
#endregion

}