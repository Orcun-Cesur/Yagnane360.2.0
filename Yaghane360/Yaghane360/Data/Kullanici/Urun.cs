using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaghane360.Data.Kullanici
{
	public class Urun
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IslemNo { get; set; }

		[ForeignKey("Musteri")]
		public int? MusteriID { get; set; }
		public Musteri Musteri { get; set; }

		public decimal ZeytinKg { get; set; }
		public DateTime? TarihGirdi { get; set; }

		[ForeignKey("Box")]
		public int? BoxID { get; set; }
		public Box Box { get; set; }

		public decimal? YagKg { get; set; }
		public DateTime? TarihCikti { get; set; }
		public bool? IslemDurum { get; set; }
	}
}
