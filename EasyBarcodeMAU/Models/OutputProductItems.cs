namespace EasyBarcodeMAU.Models;

public class OutputProductItems {
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
  
}
