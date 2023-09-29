namespace EasyBarcodeMAU {
    public partial class ProductListPage : ContentPage {
        private List<ProductItemBase> productItems;

        public ProductListPage() {
            InitializeComponent();

            // ProductModel sýnýfýndan verileri alýn
            var productModel = new ProductModel();
            productItems = productModel.MyItems;

            // Tüm ürünleri birleþtirip ListView'a baðlayýn
            var itemDescriptions = new List<string>();
            foreach (var item in productItems) {
                var description = $"ÜRÜN NUMARASI={item.Id}, Defter Numarasý={item.DefterNo}, Depo Giriþ Tarihi={item.DepoGirisTarih:dd.MM.yyyy}, Müþteri Adý ={item.MusteriAd}, Ürün Adedi ={item.UrunAdet}, Ürün Aðýrlýðý={item.UrunAgirlik}, Depo Konumu={item.DepoKonum}";
                itemDescriptions.Add(description);
            }

            ItemList.ItemsSource = itemDescriptions;
        }


        private void OnConfirmButtonClicked(object sender, EventArgs e) {
            // Burada seçilen öðeyi iþleyebilirsiniz, seçilen öðeyi almak için IdPicker.SelectedItem kullanabilirsiniz.
        }
    }
}
