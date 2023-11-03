namespace EasyBarcodeMAU.Models;

public class OutputReadBaseModel : BaseViewModel {

    public event EventHandler SelectedProductChanged;

    #region Properties

    public int Id { get; set; }
    private int _bookNumber;
    public int BookNumber {
        get { return _bookNumber; }
        set {
            if (_bookNumber != value) {
                _bookNumber = value;
                OnPropertyChanged(nameof(BookNumber));
            }
        }
    }

    public string Barcode { get; set; }

    private int _scannedBarcodes;
    public int ScannedBarcodes {
        get { return _scannedBarcodes; }
        set {
            if (_scannedBarcodes != value) {
                _scannedBarcodes = value;
                OnPropertyChanged(nameof(ScannedBarcodes));
            }
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
    private int _totalCount;
    public int TotalCount {
        get { return _totalCount; }
        set {
            if (_totalCount != value) {
                _totalCount = value;
                OnPropertyChanged(nameof(TotalCount));
            }
        }
    }


   
    public DateTime WareHouseEntry { get; set; }

    private string _customerName;
    public string CustomerName {
        get { return _customerName; }
        set {
            if (_customerName != value) {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
    }
    private string _productType;
    public string ProductType {
        get { return _productType; }
        set {
            if (_productType != value) {
                _productType = value;
                OnPropertyChanged(nameof(ProductType));
            }
        }
    }

    private int _productCount;
    public int ProductCount {
        get { return _productCount; }
        set {
            if (_productCount != value) {
                _productCount = value;
                OnPropertyChanged(nameof(ProductCount));
            }
        }
    }
    private int _productWeight;
    public int ProductWeight {
        get { return _productWeight; }
        set {
            if (_productWeight != value) {
                _productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
            }
        }
    }
    private string _wareHouseLocation;
    public string WareHouseLocation {
        get { return _wareHouseLocation; }
        set {
            if (_wareHouseLocation != value) {
                _wareHouseLocation = value;
                OnPropertyChanged(nameof(WareHouseLocation));
            }
        }
    }


    private long _requiredCount;
    public long RequiredCount {
        get { return _requiredCount; }
        set {
            if (_requiredCount != value) {
                _requiredCount = value;
                OnPropertyChanged(nameof(RequiredCount));
            }
        }
    }


    private int _readedCount;
    public int ReadedCount {
        get { return _readedCount; }
        set {
            if (_readedCount != value) {
                _readedCount = value;
                OnPropertyChanged(nameof(ReadedCount));
            }
        }
    }

    private string _selectedProduct;
    public string SelectedProduct {
        get { return _selectedProduct; }
        set {
            if (_selectedProduct != value) {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                SelectedProductChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    #endregion

}
