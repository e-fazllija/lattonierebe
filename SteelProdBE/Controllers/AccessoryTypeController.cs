using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.TypologiesModels.AccessoryTypeModels;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class AccessoryTypeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAccessoryTypeServices _accessoryTypeServices;
        private readonly ILogger<AccessoriesController> _logger;

        public AccessoryTypeController(
            IConfiguration configuration,
            IAccessoryTypeServices accessoryTypeServices,
             ILogger<AccessoriesController> logger)
        {
            _configuration = configuration;
            _accessoryTypeServices = accessoryTypeServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(AccessoryTypeCreateModel request)
        {
            try
            {
                AccessoryTypeSelectModel Result = await _accessoryTypeServices.Create(request);
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
        public async Task<IActionResult> Update(AccessoryTypeUpdateModel request)
        {
            try
            {
                AccessoryTypeSelectModel Result = await _accessoryTypeServices.Update(request);

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
                ListViewModel<AccessoryTypeSelectModel> res = await _accessoryTypeServices.Get(currentPage, filterRequest);

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
                AccessoryTypeSelectModel result = new AccessoryTypeSelectModel();
                result = await _accessoryTypeServices.GetById(id);

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
                AccessoryType result = await _accessoryTypeServices.Delete(id);
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
