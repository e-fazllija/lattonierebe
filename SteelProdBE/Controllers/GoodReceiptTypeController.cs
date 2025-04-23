using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class GoodReceiptTypeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGoodReceiptTypeServices _goodReceiptTypeServices;
        private readonly ILogger<GoodReceiptTypeController> _logger;

        public GoodReceiptTypeController(
            IConfiguration configuration,
            IGoodReceiptTypeServices goodReceiptTypeServices,
             ILogger<GoodReceiptTypeController> logger)
        {
            _configuration = configuration;
            _goodReceiptTypeServices = goodReceiptTypeServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(GoodReceiptTypeCreateModel request)
        {
            try
            {
                GoodReceiptTypeSelectModel Result = await _goodReceiptTypeServices.Create(request);
                return Ok(Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update(GoodReceiptTypeUpdateModel request)
        {
            try
            {
                GoodReceiptTypeSelectModel Result = await _goodReceiptTypeServices.Update(request);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int currentPage, string? filterRequest)
        {
            try
            {
                //currentPage = currentPage > 0 ? currentPage : 1;
                ListViewModel<GoodReceiptTypeSelectModel> res = await _goodReceiptTypeServices.Get(currentPage, filterRequest);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route(nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                GoodReceiptTypeSelectModel result = new GoodReceiptTypeSelectModel();
                result = await _goodReceiptTypeServices.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                GoodReceiptType result = await _goodReceiptTypeServices.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
    }
}
