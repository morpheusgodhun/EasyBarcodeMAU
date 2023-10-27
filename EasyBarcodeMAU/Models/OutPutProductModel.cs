using System.Collections.ObjectModel;

namespace EasyBarcodeMAU.Models;

public class OutPutProductModel : BaseViewModel {

    private static OutPutProductModel _instance;
    public static OutPutProductModel Instance => _instance ??= new OutPutProductModel();



    #region List
    public List<ProductItemBase> ProductItems { get; set; } = new List<ProductItemBase> {
            new ProductItemBase { Id = 1, DefterNo = 123321456, MusteriAd = "Beko", UrunCins = "Sunta Kenar Bandı", UrunAdet = 7839858,DepoKonum = "A Blok", RequiredCount=5, BarkodNo = 13252523,
                ScannedBarcodes = new List<long> { 1324234233, 342342342345, 6782342432 }},
            new ProductItemBase { Id = 2, DefterNo = 213213123, MusteriAd = "Penta Teknoloji", UrunCins = "Ekran Kartı", UrunAdet = 3243243, DepoKonum = "B Blok",RequiredCount=10, BarkodNo = 23325224,
                ScannedBarcodes = new List<long> { 2342342456, 732423422389, 1021312321 }},
            new ProductItemBase { Id = 3, DefterNo = 453223323, MusteriAd = "Vatan Computer", UrunCins = "MousePad", UrunAdet = 4829424, DepoKonum = "C Blok", RequiredCount=20, BarkodNo = 54325256,
                ScannedBarcodes = new List<long> { 4543534656, 783242234349, 9101342422 }},
            new ProductItemBase { Id = 4, DefterNo = 234142323, MusteriAd = "Teknosa", UrunCins = "Laptop", UrunAdet = 2935643, DepoKonum = "D Blok" , RequiredCount=30,BarkodNo = 12325323,
                ScannedBarcodes = new List<long> { 5234234356, 723523235289, 1235222201 }},
            new ProductItemBase { Id = 5, DefterNo = 533532323, MusteriAd = "Armut Kırtasiye", UrunCins = "Kitap", UrunAdet = 3539531,DepoKonum = "E Blok" , RequiredCount=40,BarkodNo = 63432254,
                ScannedBarcodes = new List<long> { 6523423426, 789324235323, 2325235201 }},
            new ProductItemBase { Id = 6, DefterNo = 234322443, MusteriAd = "FarmTown", UrunCins = "Tahıl", UrunAdet = 3539531, DepoKonum = "F Blok" , RequiredCount=50,BarkodNo = 1232152311,
                ScannedBarcodes = new List<long> { 7324222356, 782342343228, 3101342323 }},
            new ProductItemBase { Id = 7, DefterNo = 234324324, MusteriAd = "PetCat", UrunCins = "Hayvan Maması", UrunAdet = 3539531, DepoKonum = "G Blok " , RequiredCount=60,BarkodNo=12352151,
                ScannedBarcodes = new List<long> { 8342423456, 782342323149, 4324240132 }},
        };
    public ObservableCollection<OutPutProductModel> ScannedBarcodes { get; set; } = new ObservableCollection<OutPutProductModel>();
    public OutPutProductModel() {
        AddBarcodesToProductById(1, 1324234233, 342342342345, 6782342432);
        AddBarcodesToProductById(2, 2342342456, 732423422389, 1021312321);
        AddBarcodesToProductById(3, 4543534656, 783242234349, 9101342422);
        AddBarcodesToProductById(4, 5234234356, 723523235289, 1235222201);
        AddBarcodesToProductById(5, 6523423426, 789324235323, 2325235201);
        AddBarcodesToProductById(6, 7324222356, 782342343228, 3101342323);
        AddBarcodesToProductById(7, 8342423456, 782342323149, 4324240132);
    }

    #endregion

    #region Properties

    public event Action<ProductItemBase> OnDeleteSelectedItem;


    public void AddBarcodesToProductById(int productId, params long[] barcodes) {
        var product = ProductItems.FirstOrDefault(p => p.Id == productId);

        if (product != null) {
            foreach (var barcode in barcodes) {
                product.AddBarcode(barcode);
            }
        }
    }

    public void DeleteProductById(int id) {
        var productToRemove = ProductItems.FirstOrDefault(p => p.Id == id);
        if (productToRemove != null) {
            ProductItems.Remove(productToRemove);
            OnDeleteSelectedItem?.Invoke(productToRemove);
        }
    }

    private int _count;
    public int Count {
        get { return _count; }
        set {
            if (_count != value) {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }

    private string selectedProduct;
    public string SelectedProduct {
        get { return selectedProduct; }
        set {
            if (selectedProduct != value) {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

            }
        }
    }

    private string _barkodNo;
    public string BarkodNo {
        get { return _barkodNo; }
        set {
            if (_barkodNo != value) {
                _barkodNo = value;
                OnPropertyChanged(nameof(BarkodNo));

            }
        }
    }
    private string readcount;
    public string ReadCount {
        get { return readcount; }
        set {
            if (readcount != value) {
                readcount = value;
                OnPropertyChanged(nameof(ReadCount));

            }
        }
    }
    public string ScannedBarcodesString {
        get {
            return string.Join(", ", ScannedBarcodes);
        }
    }

    #endregion
}
