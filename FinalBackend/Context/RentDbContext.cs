using FinalBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalBackend.Context
{
    public class RentDbContext: IdentityDbContext<AppUser>
    {

        public DbSet<Setting> settings { get; set; }    
        public DbSet<Company> companies { get; set; }    
        public RentDbContext(DbContextOptions<RentDbContext> options):base(options)
        {

        }
    }



   
}
