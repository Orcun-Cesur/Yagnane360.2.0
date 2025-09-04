using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaghane360.Data.Kullanici
{
	public class Box
	{
		[Key]
		public int BoxID { get; set; }
		public decimal? Miktar { get; set; }

		[ForeignKey("Musteri")]
		public int? MusteriID { get; set; }
		public Musteri Musteri { get; set; }
	}
}
