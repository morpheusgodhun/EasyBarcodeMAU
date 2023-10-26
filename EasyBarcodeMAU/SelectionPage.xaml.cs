namespace EasyBarcodeMAU;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class SelectionPage : ContentPage {
    public SelectionPage() {
        InitializeComponent();
    }

    private void ProductInputButton_Clicked(object sender, EventArgs e) {
        var selectPage = new ProductListPage();
        Navigation.PushAsync(selectPage);

    }

    private void ProductOutputButton_Clicked(object sender, EventArgs e) {
        var exitPage = new ProductListPage();
        Navigation.PushAsync(exitPage);
    }
    private async void ExitButton_Clicked(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private void OnBackPressed() {
        Navigation.PushAsync(new SelectionPage());
    }

}