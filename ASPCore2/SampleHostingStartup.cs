using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: HostingStartup(typeof(ASPCore2.SampleHostingStartup))]

namespace ASPCore2
{

    public class SampleHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureLogging((context, logging) => 
                logging.AddProvider(new FooLoggerProvider()));
        }
    }
}
