using Core.Config.DryIoc;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using LibCore.ServicesInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Contract;

namespace PersonWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseServiceProviderFactory(new DryIocServiceProviderFactory()).ConfigureContainer<Container>((hostContext, container)=>{
                    container.RegisterByAssemblyAndType<IService>("Services");
                    container.RegisterByAssemblyAndType<IRepository, IService>("Persistence.Dapper");
                   
                });
    }
}
