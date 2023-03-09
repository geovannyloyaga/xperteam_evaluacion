using Microsoft.AspNetCore.Mvc;

using xperteam.bll.Services.Contract;
using xperteam.dto;
using xperteam.api.Utility;

namespace xperteam.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        #region Properties
        private readonly IGuideService _guideService;
        #endregion

        #region Constructor
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        #endregion

        #region Routes
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var resp = new Response<List<GuideDto>>(false, new List<GuideDto>(), string.Empty);
            try
            {
                resp.status = true;
                resp.data = await _guideService.List();
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
