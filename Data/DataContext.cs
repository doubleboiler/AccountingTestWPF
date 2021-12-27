using AccountingTestWPF.Models;
using System.Data.Entity;

namespace AccountingTestWPF.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
