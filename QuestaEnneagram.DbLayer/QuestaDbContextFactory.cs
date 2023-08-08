using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


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
            var connectionString = "Data Source=questadb.cirpbpm7tkaa.ap-south-1.rds.amazonaws.com;initial catalog=QuestaEnneagram;user id=questaLive;password=Welcome2020;MultipleActiveResultSets=True";//configuration.GetConnectionString("DefaultConnection");
            dbContextOptionsBuilder
                .UseSqlServer(connectionString);

            return new QuestaDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
