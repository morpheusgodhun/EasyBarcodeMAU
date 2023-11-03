using System.Collections.ObjectModel;

namespace EasyBarcodeMAU.Models;
public class ProductItemBase {

    #region Properties

    public int Id { get; set; }
    public int BookNumber { get; set; }
    public DateTime WareHouseEntry { get; set; }
    public string CustomerName { get; set; }
    public string ProductType { get; set; }
    public int ProductCount { get; set; }
    public int ProductWeight { get; set; }
    public string WareHouseLocation { get; set; }
    public long BarkodNo { get; set; }
    public long ReadedBarcode { get; set; }
    public long RequiredCount { get; set; }
    public Color BorderColor { get; set; }
    public Frame Frame { get; set; }
    public Color OriginalBorderColor { get; set; }
    public List<long> ScannedBarcodes { get; set; } = new List<long>();

    public string ScannedBarcodesDisplay {
        get {
            return string.Join(", ", ScannedBarcodes);
        }
    }
    public void AddBarcode(long barcode) {
        ScannedBarcodes.Add(barcode);
    }

    #endregion

}