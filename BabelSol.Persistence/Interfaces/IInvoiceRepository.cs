using BabelSol.Persistence.Core;
using BabelSol.Persistence.Entities;

namespace BabelSol.Persistence.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<DataResult> GetInvoices();
        Task<DataResult> ProcessInvoices(List<InvoiceTransfer> invoices);

    }
}
