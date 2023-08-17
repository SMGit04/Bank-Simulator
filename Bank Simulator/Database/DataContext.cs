using Bank_Simulator.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Simulator.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<DatabaseModels> DatabaseModels => Set<DatabaseModels>();

    }
}
