using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BabelSol.Persistence.Context;
using BabelSol.Persistence.Core;
using BabelSol.Persistence.Entities;
using BabelSol.Persistence.Interfaces;


namespace BabelSol.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext context;
        private readonly ILogger<InvoiceRepository> logger;
        private readonly IConfiguration configuration;

        public InvoiceRepository(InvoiceContext context,
                                 ILogger<InvoiceRepository> logger,
                                 IConfiguration configuration)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<DataResult> GetInvoices()
        {
            DataResult result = new DataResult();

            try
            {
                var invoices = await this.context.Invoices.ToListAsync();

                result.Data = invoices;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["Error:GetInvoices"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<DataResult> ProcessInvoices(List<InvoiceTransfer> invoices)
        {
            DataResult result = new DataResult();

            try
            {
                await this.context.BulkInsertAsync(invoices);
                result.Message = "Invoices procced";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["Error:ProcessInvoices"];
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
