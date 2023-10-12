using Microsoft.EntityFrameworkCore;
using Stok.Ekstre.Models;

namespace Stok.Ekstre.AppDbContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
         : base(options)
        {
        }
        public DbSet<StokRaporuModel> StokRaporuModels { get; set; }
        public DbSet<STI> STI { get; set; }
    }
}
