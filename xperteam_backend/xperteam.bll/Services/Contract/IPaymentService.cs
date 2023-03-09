using xperteam.dto;

namespace xperteam.bll.Services.Contract
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> List();

        Task<PaymentDto> Create(PaymentDto guideDto);
    }
}
