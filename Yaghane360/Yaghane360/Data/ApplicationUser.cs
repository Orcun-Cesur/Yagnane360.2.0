using Microsoft.AspNetCore.Identity;

namespace Yaghane360.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
		[PersonalData]
		public string? FabrikaAdi { get; set; }

		[PersonalData]
		public int? FabrikaID { get; set; }

		[PersonalData]
		public string? Ad { get; set; }

		[PersonalData]
		public string? Soyad { get; set; }
	}
}
