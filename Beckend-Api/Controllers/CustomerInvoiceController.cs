using BLL.Interfaces;
using DAL.IReporitories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Beckend_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("_myAllowSpecificOrigins")]
    public class CustomerInvoiceController : Controller
    {
        private IInvoiceService _invoiceService;
        private ICustomerInvoiceRepository _customerInvoiceRepository;
        public CustomerInvoiceController(IInvoiceService _invoiceService, ICustomerInvoiceRepository _customerInvoiceRepository)
        {
            this._invoiceService = _invoiceService;
            this._customerInvoiceRepository = _customerInvoiceRepository;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult>  GetAllInvoices()
        {
            try
            {
                var allInvoices = await _customerInvoiceRepository.GetAllInvoices();
                return Ok(allInvoices);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }  
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromBody]Invoice customerInvoice)
        {
            try
            {
                var invoice = await _invoiceService.AddInvoice(customerInvoice);
                return Ok(invoice);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] Invoice customerInvoice)
        {
            try
            {
                bool succed = await _customerInvoiceRepository.EditInvoice(customerInvoice);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
    }
}
