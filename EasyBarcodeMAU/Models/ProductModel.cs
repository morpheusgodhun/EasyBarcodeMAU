namespace EasyBarcodeMAU.Models;
public class ProductModel : BaseViewModel {

    private static ProductModel _instance;
    public static ProductModel Instance => _instance ??= new ProductModel();

    #region List
    public List<ProductItemBase> ProductItems { get; set; } = new List<ProductItemBase> {
            new ProductItemBase { Id = 1, BookNumber = 123321456, WareHouseEntry = DateTime.Now, CustomerName = "Beko", ProductType = "Sunta Kenar Bandı", ProductCount = 7839858, ProductWeight = 195 , WareHouseLocation = "A Blok", RequiredCount=10 },
            new ProductItemBase { Id = 2, BookNumber = 213213123, WareHouseEntry = DateTime.Now, CustomerName = "Penta Teknoloji", ProductType = "Ekran Kartı", ProductCount = 3243243, ProductWeight = 250 , WareHouseLocation = "B Blok",RequiredCount=10},
            new ProductItemBase { Id = 3, BookNumber = 453223323, WareHouseEntry = DateTime.Now, CustomerName = "Vatan Computer", ProductType = "MousePad", ProductCount = 4829424, ProductWeight = 300 , WareHouseLocation = "C Blok", RequiredCount=20},
            new ProductItemBase { Id = 4, BookNumber = 234142323, WareHouseEntry = DateTime.Now, CustomerName = "Teknosa", ProductType = "Laptop", ProductCount = 2935643, ProductWeight = 500 , WareHouseLocation = "D Blok" , RequiredCount=30 },
            new ProductItemBase { Id = 5, BookNumber = 533532323, WareHouseEntry = DateTime.Now, CustomerName = "Armut Kırtasiye", ProductType = "Kitap", ProductCount = 3539531, ProductWeight = 210 , WareHouseLocation = "E Blok" , RequiredCount=40},
            new ProductItemBase { Id = 6, BookNumber = 234322443, WareHouseEntry = DateTime.Now, CustomerName = "FarmTown", ProductType = "Tahıl", ProductCount = 3539531, ProductWeight = 650 , WareHouseLocation = "F Blok" , RequiredCount=50 },
            new ProductItemBase { Id = 7, BookNumber = 234324324, WareHouseEntry = DateTime.Now, CustomerName = "PetCat", ProductType = "Hayvan Maması", ProductCount = 3539531, ProductWeight = 50 , WareHouseLocation = "G Blok " , RequiredCount=60}
        };
    #endregion

    #region Properties

    public event Action<ProductItemBase> OnDeleteSelectedItem;
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
    private int _readedBarcode;
    public int ReadedBarcode {
        get { return _readedBarcode; }
        set {
            if (_readedBarcode != value) {
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
    #endregion

}