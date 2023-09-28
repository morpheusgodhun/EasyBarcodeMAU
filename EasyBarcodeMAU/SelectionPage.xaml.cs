namespace EasyBarcodeMAU;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class SelectionPage : ContentPage {
    public SelectionPage() {
        InitializeComponent();
    }

    private void ProductInputButton_Clicked(object sender, EventArgs e) {
        //ürün giriþ ekranýna yönlendir
        var selectPage = new SelectionPage();
        Navigation.PushAsync(selectPage);

    }

    private void ProductOutputButton_Clicked(object sender, EventArgs e) {
        //ürün çýkýþ ekranýna yönlendir
        var exitPage = new SelectionPage();
        Navigation.PushAsync(exitPage);
    }
    private async void ExitButton_Clicked(object sender, EventArgs e) {
        // MainPage'e git
        await Shell.Current.GoToAsync("//MainPage");
    }

}