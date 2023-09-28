namespace EasyBarcodeMAU {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e) {

            //click sayısı öğrenmek için kod
            //int count = 0;
            //count++;           
            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }


        //kullanıcı adı şifre kontrol
        private async void OnLoginButtonClicked(object sender, EventArgs e) {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            bool isCredentialsValid = ValidateCredentials(username, password);

            if (isCredentialsValid) {
                await Navigation.PushAsync(new SelectionPage());
            }
            else {
                // Kullanıcı adı ve şifre yanlışsa kullanıcıyı uyarabilirsiniz.
                await DisplayAlert("Hata", "Kullanıcı adı veya şifre yanlış.", "Tamam");
            }
        }

        private bool ValidateCredentials(string username, string password) {
            //hazır kullanıcı adı sifre kontrolü ilerde veri tabanı üzerinden proptan çekilecek
            string validUsername = "orhun";
            string validPassword = "orhunsifre";

            return (username == validUsername && password == validPassword);
        }
    }
}