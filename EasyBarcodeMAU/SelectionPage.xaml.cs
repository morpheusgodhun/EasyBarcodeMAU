namespace EasyBarcodeMAU;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class SelectionPage : ContentPage {
    public SelectionPage() {
        InitializeComponent();
    }

    private void ProductInputButton_Clicked(object sender, EventArgs e) {
        //�r�n giri� ekran�na y�nlendir
        var selectPage = new ProductListPage();
        Navigation.PushAsync(selectPage);

    }

    private void ProductOutputButton_Clicked(object sender, EventArgs e) {
        //�r�n ��k�� ekran�na y�nlendir
        var exitPage = new ProductListPage();
        Navigation.PushAsync(exitPage);
    }
    private async void ExitButton_Clicked(object sender, EventArgs e) {
        // MainPage'e git
        await Shell.Current.GoToAsync("//MainPage");
    }

}