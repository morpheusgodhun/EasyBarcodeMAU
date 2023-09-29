namespace EasyBarcodeMAU {
    public partial class ProductListPage : ContentPage {
        private List<ProductItemBase> productItems;

        public ProductListPage() {
            InitializeComponent();

            // ProductModel s�n�f�ndan verileri al�n
            var productModel = new ProductModel();
            productItems = productModel.MyItems;

            // T�m �r�nleri birle�tirip ListView'a ba�lay�n
            var itemDescriptions = new List<string>();
            foreach (var item in productItems) {
                var description = $"�R�N NUMARASI={item.Id}, Defter Numaras�={item.DefterNo}, Depo Giri� Tarihi={item.DepoGirisTarih:dd.MM.yyyy}, M��teri Ad� ={item.MusteriAd}, �r�n Adedi ={item.UrunAdet}, �r�n A��rl���={item.UrunAgirlik}, Depo Konumu={item.DepoKonum}";
                itemDescriptions.Add(description);
            }

            ItemList.ItemsSource = itemDescriptions;
        }


        private void OnConfirmButtonClicked(object sender, EventArgs e) {
            // Burada se�ilen ��eyi i�leyebilirsiniz, se�ilen ��eyi almak i�in IdPicker.SelectedItem kullanabilirsiniz.
        }
    }
}
