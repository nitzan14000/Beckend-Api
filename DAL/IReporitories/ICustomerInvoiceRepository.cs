using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IReporitories
{
    public interface ICustomerInvoiceRepository
    {
        public Task<Invoice> AddInvoice(Invoice custoerInvoice);
        public Task<List<Invoice>> GetAllInvoices();
        public Task<Invoice> GetInvoiceById(int custoerInvoiceId);
        public Task<bool> EditInvoice(Invoice custoerInvoice);
    }
}
