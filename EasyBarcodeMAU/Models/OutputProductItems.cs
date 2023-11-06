using EasyBarcodeMAU.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace EasyBarcodeMAU.Models;

public class OutputProductItems {
    private readonly EasyDbContext context;
    public ObservableCollection<ProductItemBase> ProductItems { get; set; } = new ObservableCollection<ProductItemBase>();

    public int Id { get; set; }
    public int BookNumber { get; set; }
    public DateTime WareHouseEntry { get; set; }
    public string CustomerName { get; set; }
    public string ProductType { get; set; }
    public int ProductCount { get; set; }
    public int ProductWeight { get; set; }
    public string WareHouseLocation { get; set; }
    public long BarkodNo { get; set; }
    public long RequiredCount { get; set; }
    public Color BorderColor { get; set; }
    public Frame Frame { get; set; }
    public Color OriginalBorderColor { get; set; }

    public async Task LoadProductItemsAsync() {
        if (context == null) {
            throw new InvalidOperationException("Veritabanı bağlamı (context) başlatılmamış.");
        }

        var productItemsFromDb = await context.outPutProductModels.ToListAsync();
        ProductItems.Clear();
        foreach (var item in productItemsFromDb) {
            ProductItems.Add(item);
        }
    }

}
