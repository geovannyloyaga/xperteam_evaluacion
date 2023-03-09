using AutoMapper;
using Microsoft.EntityFrameworkCore;
using xperteam.bll.Services.Contract;
using xperteam.dal.Repositories.Contract;
using xperteam.dto;
using xperteam.model;

namespace xperteam.bll.Services
{
    public class InvoiceService : IInvoiceService
    {
        #region Properties
        private readonly IGenericRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public InvoiceService(IGenericRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<InvoiceDto>> List()
        {
            try
            {
                var invoiceList = await _invoiceRepository.Consult();
                return _mapper.Map<List<InvoiceDto>>(invoiceList.ToList());
            }
            catch
            {
                throw;
            }
        }

        public Task<InvoiceDto> Create(InvoiceDto invoiceDto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
