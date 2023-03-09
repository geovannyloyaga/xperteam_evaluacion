using AutoMapper;
using xperteam.bll.Services.Contract;
using xperteam.dal.Repositories.Contract;
using xperteam.dto;
using xperteam.model;

namespace xperteam.bll.Services
{
    public class GuideService : IGuideService
    {

        #region Properties
        private readonly IGenericRepository<Guide> _guideRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GuideService(IGenericRepository<Guide> guideRepository, IMapper mapper)
        {
            _guideRepository = guideRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<GuideDto>> List()
        {
            try
            {
                var guideList = await _guideRepository.Consult();
                return _mapper.Map<List<GuideDto>>(guideList.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<GuideDto> Create(GuideDto guideDto)
        {
            try
            {
                var guideCreated = await _guideRepository.Create(_mapper.Map<Guide>(guideDto));

                if (guideDto.IdGuide == 0)
                    throw new TaskCanceledException("No se pudo crear Guía");

                return _mapper.Map<GuideDto>(guideCreated);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
