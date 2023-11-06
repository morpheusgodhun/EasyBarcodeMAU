using EasyBarcodeMAU.Models.Aggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU.Models;

public class OutPutProductModel : ProductItemBase {
    public OutPutProductModel() { }


    #region Instance
    private static OutPutProductModel _instance;
    private readonly EasyDbContext context;


    private readonly IOutputRepositories _outputRepositories;
    public ObservableCollection<ProductItemBase> ProductItems { get; set; } = new ObservableCollection<ProductItemBase>();
    public static OutPutProductModel Instance => _instance ??= new OutPutProductModel();
    #endregion

    #region List


    public OutPutProductModel(IOutputRepositories outputRepositories) {
        _outputRepositories = outputRepositories;
    }


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
    public async Task LoadProductItemsAsync() {
        var productItemsFromDb = await context.outPutProductModels.ToListAsync();
        foreach (var item in productItemsFromDb) {

            ProductItems.Add(item);
        }
    }

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

    public int Count { get; set; }

    public string SelectedProduct { get; set; }

    public int BarcodeNumber { get; set; }

    public string ReadCount { get; set; }
    public string ScannedBarcodesString {
        get {
            return string.Join(", ", ScannedBarcodes);
        }
    }

    #endregion

}
