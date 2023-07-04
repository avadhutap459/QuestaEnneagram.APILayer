using Microsoft.EntityFrameworkCore;
using QuestaEnneagram.DbLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.DbLayer
{
    public class QuestaDbContext : DbContext
    {
        public QuestaDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-6I56UFD;Initial Catalog=DbInital;Integrated Security=True;");
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
