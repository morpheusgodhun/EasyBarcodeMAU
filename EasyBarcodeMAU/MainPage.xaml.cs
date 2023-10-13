namespace EasyBarcodeMAU;
public partial class MainPage : ContentPage {

    #region InitModel

    public MainPage() {
        InitializeComponent();
    }

    #endregion

    #region Methods

    private async void OnLoginButtonClicked(object sender, EventArgs e) {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        bool isCredentialsValid = ValidateCredentials(username, password);

        if (isCredentialsValid) {
            await Navigation.PushAsync(new SelectionPage());
        }
        else {
            await DisplayAlert("Hata", "Kullanıcı adı veya şifre yanlış.", "Tamam");
        }
    }

    private static bool ValidateCredentials(string username, string password) {
        string validUsername = "orhun";
        string validPassword = "1234";
        return (username == validUsername && password == validPassword);
    }

    #endregion

}