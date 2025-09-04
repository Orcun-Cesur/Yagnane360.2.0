using Microsoft.EntityFrameworkCore;
using Yaghane360.Data.Kullanici;

namespace Yaghane360.Data.Kullanici
{
	public class ZeytinTakipDBContext : DbContext
	{
		public ZeytinTakipDBContext(DbContextOptions<ZeytinTakipDBContext> options)
			: base(options)
		{
		}

		public DbSet<Musteri> Musteriler { get; set; }
		public DbSet<Box> Boxlar { get; set; }
		public DbSet<Urun> Urunler { get; set; }
		public DbSet<Machine> Makineler { get; set; }
		public DbSet<Kasa> Kasalar { get; set; }
		public DbSet<KasaIslemleri> KasaIslemleri { get; set; }
		public DbSet<KasaGider> KasaGider { get; set; }
	}
}
