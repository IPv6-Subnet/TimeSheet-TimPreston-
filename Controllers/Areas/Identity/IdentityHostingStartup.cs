using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionsProductionCompany.Data;
using ProductionsProductionCompany.Models.ObjectModels;

[assembly: HostingStartup(typeof(ProductionsProductionCompany.Areas.Identity.IdentityHostingStartup))]
namespace ProductionsProductionCompany.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}