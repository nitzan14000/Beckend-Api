using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public Company InvoiceCompany { get; set; }
        public DateTime CreationInvoice { get; set; }
        public Statues StatuesOrder { get; set; }
        public double TotalPrice { get; set; }
        public PaymentMethod Payment { get; set; }
        public Invoice()
        {
            CreationInvoice = new DateTime().Date;
            StatuesOrder = Statues.Paid;
        }
    }
}
