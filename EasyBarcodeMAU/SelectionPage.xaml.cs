namespace EasyBarcodeMAU;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class SelectionPage : ContentPage {

    #region InitModel

    public SelectionPage() {
        InitializeComponent();
    }
    #endregion

    #region Methods


    private void ProductInputButton_Clicked(object sender, EventArgs e) {
        var selectPage = new ProductListPage();
        Navigation.PushAsync(selectPage);

    }
    protected async void OnBackButtonPressedAsync() {
        base.OnBackButtonPressed();
        await Navigation.PushAsync(new MainPage());
    }

    private void ProductOutputButton_Clicked(object sender, EventArgs e) {
        var exitPage = new OutputProductListPage();
        Navigation.PushAsync(exitPage);
    }
    private async void ExitButton_Clicked(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//MainPage");
    }

    #endregion

}