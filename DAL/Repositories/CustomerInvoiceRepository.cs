using DAL.IReporitories;
using DB;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerInvoiceRepository : ICustomerInvoiceRepository
    {
        MyContext _myContext;
        public CustomerInvoiceRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public async Task<Invoice> AddInvoice(Invoice custoerInvoice)
        {
            await _myContext.CustomerInvoices.AddAsync(custoerInvoice);
            await _myContext.SaveChangesAsync();
            return custoerInvoice;
        }

        public async Task<bool> EditInvoice(Invoice newCustoerInvoice)
        {
            try
            {
                Invoice currentlyInvoice = await GetInvoiceById(newCustoerInvoice.Id);
                currentlyInvoice = newCustoerInvoice;
                await _myContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e) { throw new ArgumentException(e.Message); }

        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            try
            {
                var a = await _myContext.CustomerInvoices.Include(x => x.InvoiceCompany).ToListAsync();
                return a;
            }
            catch (Exception e) { throw new ArgumentException(e.Message); }

        }

        public async Task<Invoice> GetInvoiceById(int custoerInvoiceId)
        {
            return await _myContext.CustomerInvoices.Where(x => x.Id == custoerInvoiceId).FirstOrDefaultAsync();
        }
    }
}
