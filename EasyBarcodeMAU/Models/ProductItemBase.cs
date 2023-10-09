namespace EasyBarcodeMAU.Models;
    public class ProductItemBase {
        public int Id { get; set; }
        public int DefterNo { get; set; }
        public DateTime DepoGirisi { get; set; }
        public string MusteriAd { get; set; }
        public string UrunCins { get; set; }
        public int UrunAdet { get; set; }
        public int UrunAgirlik { get; set; }
        public string DepoKonum { get; set; }
        public long BarkodNo { get; set; }   
        public int? RequiredCount { get; set; }   
        public long ReadedCount { get; set; }   
    }