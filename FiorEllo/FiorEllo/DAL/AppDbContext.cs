using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FiorEllo.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
