using System.Collections.ObjectModel;

namespace EasyBarcodeMAU.Models;

public class OutPutProductModel : BaseViewModel {
    public OutPutProductModel() { }


    #region Instance
    private static OutPutProductModel _instance;
    public static OutPutProductModel Instance => _instance ??= new OutPutProductModel();
    #endregion

    #region List

    public List<ProductItemBase> ProductItems { get; set; } = new List<ProductItemBase> {
    new ProductItemBase {
        Id = 1, BookNumber = 123321456, CustomerName = "Beko", ProductType = "Sunta Kenar Bandı", ProductCount = 7839858,WareHouseLocation = "A Blok", RequiredCount=10, BarkodNo = 13252523,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {1324234233, 2}, {342342342345, 2}, { 6782342432, 2},{ 2342342456, 2},{ 1021312321, 2}  })
    },
    new ProductItemBase {
        Id = 2, BookNumber = 213213123, CustomerName = "Penta Teknoloji", ProductType = "Ekran Kartı", ProductCount = 3243243, WareHouseLocation = "B Blok",RequiredCount=10, BarkodNo = 23325224,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {2342342456, 4}, {7324234223, 4}, {1021312321, 2} })
    },
    new ProductItemBase {
        Id = 3, BookNumber = 453223323, CustomerName = "Vatan Computer", ProductType = "MousePad", ProductCount = 4829424, WareHouseLocation = "C Blok", RequiredCount=20, BarkodNo = 54325256,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {4543534656, 7}, {7832422343, 7}, {9101342422, 6} })
    },
    new ProductItemBase {
        Id = 4, BookNumber = 234142323, CustomerName = "Teknosa", ProductType = "Laptop", ProductCount = 2935643, WareHouseLocation = "D Blok", RequiredCount=30,BarkodNo = 12325323,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {5234234356, 10}, {7235232352, 10}, {1235222201, 10} })
    },
    new ProductItemBase {
        Id = 5, BookNumber = 533532323, CustomerName = "Armut Kırtasiye", ProductType = "Kitap", ProductCount = 3539531,WareHouseLocation = "E Blok", RequiredCount=40,BarkodNo = 63432254,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {6523423426, 10}, {7893242353, 20}, {2325235201, 10} })
    },
    new ProductItemBase {
        Id = 6, BookNumber = 234322443, CustomerName = "FarmTown", ProductType = "Tahıl", ProductCount = 3539531, WareHouseLocation = "F Blok", RequiredCount=50,BarkodNo = 1232152311,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {7324222356, 20}, {7823423432, 20}, {3101342323, 10} })
    },
    new ProductItemBase {
        Id = 7, BookNumber = 234324324, CustomerName = "PetCat", ProductType = "Hayvan Maması", ProductCount = 3539531, WareHouseLocation = "G Blok", RequiredCount=60,BarkodNo=12352151,
        ScannedBarcodes = ConvertBarcodeDictionaryToList(new Dictionary<long, int> { {8342423456, 20}, {7823423231, 20}, {4324240132, 20} })
    }
};
    public ObservableCollection<OutPutProductModel> ScannedBarcodes { get; set; } = new ObservableCollection<OutPutProductModel>();
    private static List<long> ConvertBarcodeDictionaryToList(Dictionary<long, int> barcodeDict) {
        List<long> result = new List<long>();

        foreach (var pair in barcodeDict) {
            for (int i = 0; i < pair.Value; i++) {
                result.Add(pair.Key);
            }
        }
        return result;
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
