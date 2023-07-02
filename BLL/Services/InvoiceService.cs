using BLL.Interfaces;
using DAL.IReporitories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICustomerInvoiceRepository _customerInvoiceRepository;
        public InvoiceService(ICustomerInvoiceRepository _customerInvoiceRepository)
        {
            this._customerInvoiceRepository = _customerInvoiceRepository;  
        }

        public async Task<Invoice> AddInvoice(Invoice custoerInvoice)
        {
            custoerInvoice.TotalPrice = CalculateTotalPrice(custoerInvoice);
            var invoice = await _customerInvoiceRepository.AddInvoice(custoerInvoice);
            return invoice;
        }

        private double CalculateTotalPrice(Invoice cusetomerInvoice)
        {
            foreach (var item in cusetomerInvoice.Products)
            {
                cusetomerInvoice.TotalPrice += item.Price*item.Amount;
            }
            return cusetomerInvoice.TotalPrice;
        }

        public async Task<bool> EditInvoice(Invoice custoerInvoice)
        {
            custoerInvoice.TotalPrice = CalculateTotalPrice(custoerInvoice);
            var succed = await _customerInvoiceRepository.EditInvoice(custoerInvoice);
            return succed;
        }
    }
}
