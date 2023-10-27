using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
public partial class OutputProductListPage : ContentPage {

    #region Variables
    private Frame lastTappedFrame;
    #endregion

    #region InitModel
    public OutputProductListPage() {
        InitializeComponent();
        var outputproductModel = new OutPutProductModel();
        BindingContext = outputproductModel;
        outputproductModel.OnDeleteSelectedItem += HandleItemDeletion;
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext = null;
        BindingContext = new OutPutProductModel();
    }
    #endregion

    


    #region Methods

    private void HandleItemDeletion(ProductItemBase deletedItem) {
        BindingContext = null;
        BindingContext = new OutPutProductModel();
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
                var scanPage = new OutputScanBarcodeScreen(itemBase);
                await Navigation.PushAsync(scanPage);
            }
        }
    }
    private void OnConfirmButtonClicked(object sender, EventArgs e) {
        var scanPage = new OutputScanBarcodeScreen();
        Navigation.PushAsync(scanPage);
    }

    #endregion

}