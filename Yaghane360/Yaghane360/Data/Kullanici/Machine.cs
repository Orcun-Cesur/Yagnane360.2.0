using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaghane360.Data.Kullanici
{
	public class Machine
	{
		[Key]
		public int MachineID { get; set; }
		public string MachineName { get; set; }

		[ForeignKey("Urun")]
		public int? IslemNo { get; set; }
		public Urun? Urun { get; set; }
		public TimeSpan? ZamanSayaci { get; set; } = TimeSpan.Zero;
	}
}
