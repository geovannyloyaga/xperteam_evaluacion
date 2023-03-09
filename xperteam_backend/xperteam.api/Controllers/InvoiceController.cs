using Microsoft.AspNetCore.Mvc;

using xperteam.bll.Services.Contract;
using xperteam.dto;
using xperteam.api.Utility;

namespace xperteam.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Properties
        private readonly IInvoiceService _invoiceService;
        #endregion

        #region Constructor
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        #endregion

        #region Routes
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var resp = new Response<List<InvoiceDto>>(false, new List<InvoiceDto>(), string.Empty);
            try
            {
                resp.status = true;
                resp.data = await _invoiceService.List();
            }
            catch (Exception ex)
            {
                resp.status = false;
                resp.message = ex.Message;
            }
            return Ok(resp);
        }
        #endregion
    }
}
