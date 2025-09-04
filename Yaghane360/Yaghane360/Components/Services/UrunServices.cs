using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Yaghane360.Data.Kullanici;
using Yaghane360.Components.Services;

namespace Yaghane360.Components.Services
{
	public class UrunServices
	{
		private readonly ZeytinTakipDBContext _context;
		public UrunServices(ZeytinTakipDBContext context)
		{
			_context = context;
		}
		[Inject] public MusteriServices MusteriAracları { get; set; }
		public async Task<string> KiriciKontrolAsync(Urun gosterilecekUrun)
		{
			int machineId = 1;

			while (true)
			{
				var machine = await _context.Makineler
					.FirstOrDefaultAsync(m => m.MachineID == machineId);

				if (machine != null && (machine.IslemNo == null || machine.IslemNo == 0))
				{
					machine.IslemNo = gosterilecekUrun.IslemNo;
					gosterilecekUrun.IslemDurum = true;
					await _context.SaveChangesAsync();
					return "Sonraki aşama hazır";
				}
				await Task.Delay(2000); // 5 saniye bekle
			}
		}
		public async Task<List<Machine>> GetMakinelerWithDetailsAsync()
		{
			return await _context.Makineler
				.Where(m => m.MachineID >= 2 && m.MachineID <= 7)
				.Include(m => m.Urun)          // Makineye bağlı ürün
				.ThenInclude(u => u.Musteri)   // Ürüne bağlı müşteri
				.ToListAsync();
		}
		public async Task MalaksorSecildi(int machineID)
		{
			List<Machine> makineler = new();
			makineler = await GetMakinelerWithDetailsAsync();
			Console.WriteLine($"Makine {machineID} seçildi!");
			// Eğer sadece boşlar için işlem yapılacaksa:
			var kirici = await _context.Makineler.Where(m => m.MachineID >= 1)
				 .Include(m => m.Urun)
				 .ThenInclude(u => u.Musteri)
				 .FirstOrDefaultAsync(m => m.MachineID == 1);
			var secilenMalaksor = makineler.FirstOrDefault(m => m.MachineID == machineID);
			if (kirici.Urun != null)
			{
				secilenMalaksor.IslemNo = kirici.Urun.IslemNo;
				kirici.IslemNo = null;
				kirici.Urun = null;
				await _context.SaveChangesAsync();
			}
		}
		public async Task DekantorAta(int machineID)
		{
			string hataMesaji;
			List<Machine> makineler = new();
			makineler = await GetMakinelerWithDetailsAsync();
			Console.WriteLine($"Makine {machineID} seçildi!");
			// Eğer sadece boşlar için işlem yapılacaksa:
			var secilenMalaksor = await _context.Makineler
				.Include(m => m.Urun)
				.ThenInclude(u => u.Musteri)
				.FirstOrDefaultAsync(m => m.MachineID == machineID);

			var dekantor = await _context.Makineler
				.Include(m => m.Urun)
				.ThenInclude(u => u.Musteri)
				.FirstOrDefaultAsync(m => m.MachineID == 8);
			if (secilenMalaksor != null && secilenMalaksor.IslemNo != 0)
			{
				var urun = secilenMalaksor.Urun;
				secilenMalaksor.Urun = null;
				secilenMalaksor.IslemNo = null;

				dekantor.Urun = urun;
				dekantor.IslemNo = urun?.IslemNo;

				//dekantor.IslemNo = secilenMalaksor.IslemNo;
				//dekantor.Urun = secilenMalaksor.Urun;
				//secilenMalaksor.IslemNo = 0;
				//secilenMalaksor.Urun = null;
				/*_context.Entry(dekantor).State = EntityState.Modified;
				_context.Entry(secilenMalaksor).State = EntityState.Modified;*/

				//_context.Makineler.Update(dekantor);
				//_context.Makineler.Update(secilenMalaksor);
				await _context.SaveChangesAsync();
			}
			else
			{
				hataMesaji = "Dekantör dolu \nDekantör ataması yapılamıyor...";
			}
		}
	}
}
