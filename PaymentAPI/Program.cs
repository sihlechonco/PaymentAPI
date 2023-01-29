using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isService = false;

            if(Debugger.IsAttached == false && args.Contains("--service"))
            {
                isService = true;
            }

            if(isService)
            {
                var pathToContentRoot = Directory.GetCurrentDirectory();

                //var webHostArgs = args.Where(arg => arg != "--console").ToArray();

                string ConfigationFile = "";
                string portNo = "6001";

                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;

                pathToContentRoot = Path.GetDirectoryName(pathToExe);

                string AppJsonFilePath = Path.Combine(pathToContentRoot, ConfigationFile);

                if(File.Exists(AppJsonFilePath))
                {
                    using(StreamReader sr = new StreamReader(AppJsonFilePath))
                    {
                        string JSONData = sr.ReadToEnd();
                        JObject jObject = JObject.Parse(JSONData);
                        if (jObject["ServicePort"] != null)
                            portNo = jObject["ServicePort"].ToString();
                    }
                }

                var host = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .UseStartup<Startup>()
                    .UseUrls("https://localhost:" + portNo)
                    .Build();

                host.RunAsync();
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
