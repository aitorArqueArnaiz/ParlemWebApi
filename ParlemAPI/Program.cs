using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text;

namespace parlemWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create connection string file
            string path = Directory.GetCurrentDirectory() + "ConnectionString.txt";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Parlem;"
                                    + "Integrated Security=true;" + Environment.NewLine;
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
