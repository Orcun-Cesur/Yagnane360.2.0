using System.ComponentModel.DataAnnotations;

namespace Yaghane360.Data
{
	public class KasaIslemleri
	{
		[Key]
		public int KasaIslemNo { get; set; }
		public int KasaID { get; set; }
		public string KasaAdi { get; set; }
		public Kasa Kasa { get; set; }
		public Musteri Musteri { get; set; }
		public decimal Miktar { get; set; }
		public DateTime Tarih { get; set; }
		public string IslemiYapanKisi { get; set; }
	}
}
