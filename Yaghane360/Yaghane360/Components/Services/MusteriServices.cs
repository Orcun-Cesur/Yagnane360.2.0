using Yaghane360.Data.Kullanici;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Yaghane360.Components.Pages;


namespace Yaghane360.Components.Services
{
	public class MusteriServices
	{
		private readonly ZeytinTakipDBContext _context;

		public MusteriServices(ZeytinTakipDBContext context)
		{
			_context = context;
		}
		public async Task<List<Musteri>> GetAllMusteri()
		{
			return await _context.Musteriler
				.Where(m => m.Isim != "[Silindi]")
				.ToListAsync();
		}
		public async Task<List<Box>> GetAllBox()
		{
			return await _context.Boxlar.ToListAsync();
		}
		public async Task<List<Urun>> GetAllUrun()
		{
			return await _context.Urunler
				.Include(u => u.Musteri)
				.ToListAsync();
		}
		public async Task MusteriAdd(Musteri musteri)
		{
			try
			{
				_context.Musteriler.Add(musteri);

				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine("HATA: " + ex.Message);
				throw; // İstersen yeniden fırlatma, logla
			}
		}
		public async Task<Musteri> GetMusteriByIdAsync(int? musteriId)
		{
			return await _context.Musteriler.FirstOrDefaultAsync(m => m.MusteriID == musteriId);
		}
		public async Task<Urun> GetUrunByNoAsync(int IslemNo)
		{
			return await _context.Urunler.FirstOrDefaultAsync(m => m.IslemNo == IslemNo);
		}
		public async Task UpdateMusteriAsync(Musteri musteri)
		{
			_context.Musteriler.Update(musteri);
			await _context.SaveChangesAsync();
		}
		public async Task MusteriDeleteAsync(int musteriId)
		{
			var musteri = await _context.Musteriler.FindAsync(musteriId);
			if (musteri != null)
			{
				musteri.Isim = "[Silindi]";
				musteri.Soyisim = "[Silindi]";
				musteri.Telefon = "[Silindi]";
				musteri.Bolge = "[Silindi]";
				musteri.Adres = "[Silindi]";
				musteri.StokYag = 0;
				musteri.StokZeytin = 0;
				musteri.Borc = 0;

				_context.Musteriler.Update(musteri);
				await _context.SaveChangesAsync();
			}
		}
		public async Task BoxGuncelle(Box box)
		{

		}
	}
}
