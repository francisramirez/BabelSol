

using BabelSol.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabelSol.Persistence.Context
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) :base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceTransfer> InvoiceTransfers { get; set; }
    }
}
