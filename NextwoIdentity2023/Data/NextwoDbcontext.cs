using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextwoIdentity2023.Models.ViewModel;
using System.Reflection.Metadata;

namespace NextwoIdentity2023.Data
{
    public class NextwoDbcontext:IdentityDbContext
    {
        public NextwoDbcontext(DbContextOptions<NextwoDbcontext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}
