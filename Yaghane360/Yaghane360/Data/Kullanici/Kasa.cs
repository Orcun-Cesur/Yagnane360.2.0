using System.ComponentModel.DataAnnotations;
using Yaghane360.Migrations.ZeytinTakipDB;

namespace Yaghane360.Data.Kullanici
{
	public class Kasa
	{
		[Key]
		public int KasaID { get; set; }
		public string KasaAdi { get; set; }
		public decimal? Miktar { get; set; }
		public List<KasaIslemleri> Islemler { get; set; }


	}
}
