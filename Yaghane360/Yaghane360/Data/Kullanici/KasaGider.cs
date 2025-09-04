using System.ComponentModel.DataAnnotations;

namespace Yaghane360.Data.Kullanici
{
	public class KasaGider
	{
		[Key]
		public int KasaGiderID { get; set; }
		public int KasaID { get; set; }
		public Kasa Kasa { get; set; }
		public Musteri? Musteri { get; set; }
		public decimal Miktar { get; set; }
		public string GiderTuru { get; set; } 
		public string? Aciklama { get; set; }
		public DateTime Tarih { get; set; }
		public string IslemiYapanKisi { get; set; }
	}
}
