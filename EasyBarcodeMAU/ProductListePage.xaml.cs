using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
public partial class ProductListPage : ContentPage {

    #region Variables
    private Frame lastTappedFrame;
    #endregion

    #region InitModel
    public ProductListPage() {
        InitializeComponent();
        var productModel = new ProductModel();
        BindingContext = productModel;
        productModel.OnDeleteSelectedItem += HandleItemDeletion;
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext = null;
        BindingContext = new ProductModel();
    }
    #endregion

    #region Methods

    private void HandleItemDeletion(ProductItemBase deletedItem) {
        BindingContext = null;
        BindingContext = new ProductModel();
    }
    private async void Frame_Tapped(object sender, EventArgs e) {
        if (lastTappedFrame != null) {
            lastTappedFrame.BorderColor = Color.FromRgb(173, 216, 230);
        }
        if (sender is Frame tappedFrame) {
            var greenColor = Color.FromRgba(255, 0, 0, 255);
            tappedFrame.BorderColor = greenColor;
            lastTappedFrame = tappedFrame;

            if (tappedFrame.BindingContext is ProductItemBase itemBase) {
                var scanPage = new ScanBarcodeScreen(itemBase);
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