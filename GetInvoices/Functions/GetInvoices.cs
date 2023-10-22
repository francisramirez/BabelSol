using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BabelSol.Persistence.Interfaces;
using GetInvoices.Api.Interfaces;
using System.Collections.Generic;
using BabelSol.Persistence.Entities;

namespace GetInvoices.Functions
{
    public class GetInvoices
    {

        private readonly IInvoiceRepository invoiceRepository;
        private readonly IInvoiceApiService invoiceApi;

        public GetInvoices(IInvoiceRepository invoiceRepository,
                           IInvoiceApiService invoiceApi)
        {
            this.invoiceRepository = invoiceRepository;
            this.invoiceApi = invoiceApi;
        }

        [FunctionName("GetInvoices")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Consultando Facturas");

            var result = await this.invoiceRepository.GetInvoices();

            if (!result.Success)
            {
                return new OkObjectResult(result);
            }
            else
            {
                
                result = await this.invoiceApi.ProccessInvoices(result.Data);
            }

            return new OkObjectResult(result);
        }
    }
}
