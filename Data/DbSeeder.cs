using Microsoft.AspNetCore.Identity;
using WebPharmacy.Areas.Identity;

namespace WebPharmacy.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Lấy các dịch vụ cần thiết
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // Tạo các vai trò
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            // Tạo tài khoản Admin mặc định
            var admin = new ApplicationUser
            {
                UserName = "admin@webpharmacy.com",
                Email = "admin@webpharmacy.com",
                Name = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(admin.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
