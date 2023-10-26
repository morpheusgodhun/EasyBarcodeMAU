namespace EasyBarcodeMAU.Models;
public class ProductItemBase {

    #region Properties

    public int Id { get; set; }
    public int DefterNo { get; set; }
    public DateTime DepoGirisi { get; set; }
    public string MusteriAd { get; set; }
    public string UrunCins { get; set; }
    public int UrunAdet { get; set; }
    public int UrunAgirlik { get; set; }
    public string DepoKonum { get; set; }
    public long BarkodNo { get; set; }
    public long RequiredCount { get; set; }
    public Color BorderColor { get; set; }
    public Frame Frame { get; set; }
    public Color OriginalBorderColor { get; set; }
    #endregion

}