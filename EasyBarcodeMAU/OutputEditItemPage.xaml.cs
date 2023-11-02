using System.Collections.ObjectModel;
using EasyBarcodeMAU.Models;

namespace EasyBarcodeMAU;
public partial class OutputEditItemPage : ContentPage {

    #region Variables

    private int _readedCount;
    private string _musteriAd;
    private string _urunCins;
    private int _count = 0;
    private ProductItemBase _selectedItem;
    private ReadBaseModel _viewModel;
    private ProductItemBase viewModel;
    private ObservableCollection<ReadBaseModel> scannedBarcodes;

    #endregion

    #region InitModel
    public OutputEditItemPage(ProductItemBase selectedItem, int readedCount, string urunCins, string musteriAd, ObservableCollection<ReadBaseModel> scannedBarcodes) {
        InitializeComponent();
        _selectedItem = selectedItem;
        _readedCount = readedCount;
        _urunCins = urunCins;
        _musteriAd = musteriAd;
        viewModel = new ProductItemBase();
        this.scannedBarcodes = scannedBarcodes;
        _viewModel = new ReadBaseModel();
        _viewModel.ReadedCount = _readedCount;
        _viewModel.UrunCins = _urunCins;
        _viewModel.MusteriAd = _musteriAd;
        _viewModel.Count = _count;
        BindingContext = _viewModel;
    }

    #endregion

    #region Methods
    protected override void OnAppearing() {
        base.OnAppearing();
        barcodeListView.ItemsSource = scannedBarcodes;
        ReadBaseModel viewModel = (ReadBaseModel)BindingContext;
        viewModel.TotalCount = _viewModel.ReadedCount;
    }

    private void Guncelle_Clicked(object sender, EventArgs e) {
        int newCount = _viewModel.Count;
        _viewModel.Count = newCount;
        _viewModel.TotalCount = scannedBarcodes.Sum(item => item.Count);
    }
    private void ArtirAzaltButton_Clicked(object sender, EventArgs e) {
        var button = (Button)sender;
        var selectedItem = (ReadBaseModel)button.CommandParameter;
        if (selectedItem != null) {
            if (button.Text == "+") {
                selectedItem.Count++;
                _viewModel.TotalCount++;
            }
            else if (button.Text == "-" && selectedItem.Count > 0) {
                selectedItem.Count--;
                _viewModel.TotalCount--;
            }
        }
    }

    private async void Kaydet_Clicked(object sender, EventArgs e) {
            await DisplayAlert("Ba�ar�l�", "Ba�ar�yla Kaydedildi", "Tamam");
            await Navigation.PushAsync(new SelectionPage());
        }            

    private async void Vazgec_Clicked(object sender, EventArgs e) {
        await Navigation.PopAsync();
    }

    #endregion
}