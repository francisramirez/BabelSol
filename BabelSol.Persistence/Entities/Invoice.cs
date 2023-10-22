

using System.ComponentModel.DataAnnotations;

namespace BabelSol.Persistence.Entities
{
    public class Invoice
    {
        [Key]
        public string? Identification { get; set; }
        public string? SiteNumber { get; set; }
        public string? InvoiceType { get; set; }
        public string? Ncf { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? NcfExpirationDate { get; set; }
        public int? BranchId { get; set; }
        public string? Branch { get; set; }
        public string? IntermediaryId { get; set; }
        public string? IntermediaryName { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? Concept { get; set; }
        public string? InvoiceConcept { get; set; }
        public string? Policy { get; set; }
        public string? TransactionType { get; set; }
        public string? ProductId { get; set; }
        public string? Product { get; set; }
        public int? PlanTypeCode { get; set; }
        public string? PlanTypeName { get; set; }
        public string? AgreementPlanId { get; set; }
        public string? AutomaticPayment { get; set; }
        public DateTime? ValidityDateStart { get; set; }
        public DateTime? ValidityDateEnd { get; set; }
        public int? FrequencyId { get; set; }
        public string? FrequencyDescription { get; set; }
        public DateTime? InvoiceExpirationDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? PendingBalance { get; set; }
    }
}
