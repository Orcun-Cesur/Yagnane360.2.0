using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaghane360.Data.Kullanici
{
	public class Musteri
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int MusteriID { get; set; }
		public string? Isim { get; set; }
		public string? Soyisim { get; set; }
		public string? Adres { get; set; }
		public string? Bolge { get; set; }
		public string? Telefon { get; set; }
		public decimal Borc { get; set; }
		public decimal StokYag { get; set; }
		public decimal StokZeytin { get; set; }
		public decimal ZeytinHacim { get; set; } = 0;
		public decimal YagHacim { get; set; } = 0;
		//public decimal IslemeUcreti { get; set; }
		public ICollection<Box> Boxlar { get; set; }
		public ICollection<Urun> Urunler { get; set; }
	}
}
