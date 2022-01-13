using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public override DbSet<IdentityUser> Users { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
