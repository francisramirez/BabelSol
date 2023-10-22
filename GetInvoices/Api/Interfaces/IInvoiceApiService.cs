

using BabelSol.Persistence.Core;
using BabelSol.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetInvoices.Api.Interfaces
{
    public interface IInvoiceApiService
    {
        Task<DataResult> ProccessInvoices(List<Invoice> invoices);
    }
}
