using AutoMapper;
using xperteam.dto;
using xperteam.model;

namespace xperteam.utility
{
    public class AutoMapperProfile : Profile
    {
        #region Constructor
        public AutoMapperProfile()
        {
            #region Model Guide
            CreateMap<Guide, GuideDto>().ReverseMap();
            #endregion

            #region Model Invoice
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            #endregion

            #region Model Payment
            CreateMap<Payment, PaymentDto>().ReverseMap();
            #endregion
        }
        #endregion
    }
}
