using System.ComponentModel.DataAnnotations;

namespace Yaghane360.Data
{
	public class Kasa
	{
		[Key]
		public int KasaID { get; set; }
		public string KasaAdi { get; set; }
		public decimal? Miktar { get; set; }
	}
}
