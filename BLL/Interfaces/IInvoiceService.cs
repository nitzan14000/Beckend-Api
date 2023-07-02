using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IInvoiceService
    {
        public Task<Invoice> AddInvoice(Invoice custoerInvoice);
        public Task<bool> EditInvoice(Invoice custoerInvoice);
    }
}
