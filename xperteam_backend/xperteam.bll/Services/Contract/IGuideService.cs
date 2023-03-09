using xperteam.dto;

namespace xperteam.bll.Services.Contract
{
    public interface IGuideService 
    {

        Task<List<GuideDto>> List();

        Task<GuideDto> Create(GuideDto guideDto);
    }
}
