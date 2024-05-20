namespace CoreEmpty1
{
    public class Program
    {

        //Host trien khai tu interface host obj:
        //-  dependence injection : isevrceprovider 
        // - logging : iloging
        // - configuration
        // - IHostBuildeder => startAsync : run HTTP
        public static void Main(string[] args)
        {
            //var builder = webapplication.createbuilder(args);
            //var app = builder.build();

            //app.mapget("/", () => "hello world!");

            //app.run();

            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
            {
                // tuy bien them ve host
                webBuilder.UseStartup<NameClassStartup>
            }
            );
            IHost host = builder.Build();
            host.Run();
        }
    }
}