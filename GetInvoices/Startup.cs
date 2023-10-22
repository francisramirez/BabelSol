using BabelSol.Persistence.Context;
using BabelSol.Persistence.Interfaces;
using BabelSol.Persistence.Repositories;
using GetInvoices.Api;
using GetInvoices.Api.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GetInvoices.Startup))]
namespace GetInvoices
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var invoiceConnString = builder.GetContext().Configuration.GetValue<string>("invoiceConnString");
           
            builder.Services.AddDbContext<InvoiceContext>(options => options.UseSqlServer(invoiceConnString));

            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();

            builder.Services.AddHttpClient();

            builder.Services.AddTransient<IInvoiceApiService, InvoiceApiService>();

        
        }

        
    }
}
