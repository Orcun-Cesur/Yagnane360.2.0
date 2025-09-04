using System.ComponentModel.DataAnnotations;

namespace Yaghane360.Data.Kullanici
{
	public class YagBidon
	{
		[Key]
		public int BidonID { get; set; }
		public decimal YagKG { get; set; }
		public string? Aciklama { get; set; }
		public DateTime Tarih { get; set; }
		public string IslemiYapanKisi { get; set; }
		public Musteri? Musteri { get; set; }
		public Urun? Urun { get; set; }
	}
}
