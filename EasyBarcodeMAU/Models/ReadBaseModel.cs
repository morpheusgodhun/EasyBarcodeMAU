namespace EasyBarcodeMAU.Models;
public class ReadBaseModel {
    public int Id { get; set; }
    public int DefterNo { get; set; }
    public DateTime DepoGirisi { get; set; }
    public string MusteriAd { get; set; }
    public string UrunCins { get; set; }
    public int UrunAdet { get; set; }
    public int UrunAgirlik { get; set; }
    public string DepoKonum { get; set; }
    public long BarcodeValue { get; set; }
}
