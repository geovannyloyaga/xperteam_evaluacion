
using xperteam.dto;

namespace xperteam.bll.Services.Contract
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> List();

        Task<InvoiceDto> Create(InvoiceDto invoiceDto);
    }
}
