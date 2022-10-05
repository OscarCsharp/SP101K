using Microsoft.EntityFrameworkCore;
using SP101K.Entities;
using System.Collections.Generic;

namespace SP101K.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
