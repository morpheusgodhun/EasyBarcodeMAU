namespace EasyBarcodeMAU.Models;

public class OutputReadBaseModel : BaseViewModel {

    public event EventHandler SelectedProductChanged;

    #region Properties

    public int Id { get; set; }
    private int _defterNo;
    public int DefterNo {
        get { return _defterNo; }
        set {
            if (_defterNo != value) {
                _defterNo = value;
                OnPropertyChanged(nameof(DefterNo));
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


   
    public DateTime DepoGirisi { get; set; }

    private string _musteriAd;
    public string MusteriAd {
        get { return _musteriAd; }
        set {
            if (_musteriAd != value) {
                _musteriAd = value;
                OnPropertyChanged(nameof(MusteriAd));
            }
        }
    }
    private string _urunCins;
    public string UrunCins {
        get { return _urunCins; }
        set {
            if (_urunCins != value) {
                _urunCins = value;
                OnPropertyChanged(nameof(UrunCins));
            }
        }
    }

    private int _urunAdet;
    public int UrunAdet {
        get { return _urunAdet; }
        set {
            if (_urunAdet != value) {
                _urunAdet = value;
                OnPropertyChanged(nameof(UrunAdet));
            }
        }
    }
    private int _urunAgirlik;
    public int UrunAgirlik {
        get { return _urunAgirlik; }
        set {
            if (_urunAgirlik != value) {
                _urunAgirlik = value;
                OnPropertyChanged(nameof(UrunAgirlik));
            }
        }
    }
    private string _depoKonum;
    public string DepoKonum {
        get { return _depoKonum; }
        set {
            if (_depoKonum != value) {
                _depoKonum = value;
                OnPropertyChanged(nameof(DepoKonum));
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
