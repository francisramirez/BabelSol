using BabelSol.Persistence.Core;
using BabelSol.Persistence.Entities;
using BabelSol.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabelSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        [HttpPost("ProccessInvoice")]
        public async Task<IActionResult> ProccessInvoices([FromBody] List<InvoiceTransfer> invoices) 
        {
            DataResult result = new DataResult();

            result = await this.invoiceRepository.ProcessInvoices(invoices);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
