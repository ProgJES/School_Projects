using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment4.Controllers
{
    public class InvoiceBase
    {
        public InvoiceBase() { }

        [Key]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        
        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        public string BillingCity { get; set; }

        [StringLength(40)]
        public string BillingState { get; set; }

        [StringLength(40)]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }
    }
    public class InvoiceWithDetail : InvoiceBase
    {
        public InvoiceWithDetail()
        {
            InvoiceLines = new List<InvoiceLineWithDetail>();
        }
        
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }
        public IEnumerable<InvoiceLineWithDetail> InvoiceLines { get; set; }
    }     
}