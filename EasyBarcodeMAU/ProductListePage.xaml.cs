namespace EasyBarcodeMAU {
    public partial class ProductListPage : ContentPage {
        private List<ProductItemBase> productItems;

        public ProductListPage() {
            InitializeComponent();

            var productModel = new ProductModel();
            productItems = productModel.MyItems;

            var itemDescriptions = new List<string>();
            foreach (var item in productItems) {
                var description =
                    $"�R�N NUMARASI={item.Id}, Defter Numaras�={item.DefterNo}, Depo Giri� Tarihi={item.DepoGirisTarih:dd.MM.yyyy}, M��teri Ad� ={item.MusteriAd}, �r�n Adedi ={item.UrunAdet}, �r�n A��rl���={item.UrunAgirlik}, Depo Konumu={item.DepoKonum}";
                itemDescriptions.Add(description);
            }

        }

        async void Frame_Tapped(object sender, EventArgs e)
        {
            if (sender is Frame tappedFrame)
            {
                if (tappedFrame.Content is StackLayout stackLayout)
                {
                    if (stackLayout.Children[0] is Grid grid)
                    {
                        List<string> labelContents = new List<string>();

                        foreach (var child in grid.Children) {
                            if (child is Label label) {
                                string labelText = label.Text;
                                labelContents.Add(labelText);
                            }
                        }
                        string message = string.Join("\n", labelContents);
                        await DisplayAlert("Label ��erikleri", message, "Tamam");
                    }
                }
            }
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e) {
            var scanPage = new ScanBarcodeScreen();
            Navigation.PushAsync(scanPage);
        }
    }
}
