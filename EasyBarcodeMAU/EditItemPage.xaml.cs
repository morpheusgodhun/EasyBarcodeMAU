using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;

public partial class EditItemPage : ContentPage {


    private ScanBarcodeScreen _scanBarcodeScreen;
    private ReadBaseModel _readviewModel;
    private EditItemBase _editItemBase;



    public EditItemPage() {
        InitializeComponent();
        _readviewModel = new ReadBaseModel();
        BindingContext = _editItemBase;
    }
}