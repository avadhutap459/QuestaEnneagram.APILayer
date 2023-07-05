using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.DbLayer
{
    public class QuestaDbContextFactory : IDesignTimeDbContextFactory<QuestaDbContext>
    {
        public static string appDirectory = System.Environment.CurrentDirectory;
        public static string env = string.Empty;
        
        public QuestaDbContext CreateDbContext(string[] args)
        {
            string Path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf('\\')) + '\\' + "QuestaEnneagram.APILayer";

            var config = new ConfigurationBuilder().SetBasePath(Path).AddJsonFile("appsettings.json").Build();

            env = config.GetSection("Env").Value;

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path)
                .AddJsonFile($"appsettings.{env}.json")
                .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<QuestaDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbContextOptionsBuilder
                .UseSqlServer(connectionString);

            return new QuestaDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
