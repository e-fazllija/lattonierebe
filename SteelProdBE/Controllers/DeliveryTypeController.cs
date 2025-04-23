using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.TypologiesModels.DeliveryTypeModels;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class DeliveryTypeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IDeliveryTypeServices _deliveryTypeServices;
        private readonly ILogger<DeliveryTypeController> _logger;

        public DeliveryTypeController(
            IConfiguration configuration,
            IDeliveryTypeServices deliveryTypeServices,
             ILogger<DeliveryTypeController> logger)
        {
            _configuration = configuration;
            _deliveryTypeServices = deliveryTypeServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(DeliveryTypeCreateModel request)
        {
            try
            {
                DeliveryTypeSelectModel Result = await _deliveryTypeServices.Create(request);
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
        public async Task<IActionResult> Update(DeliveryTypeUpdateModel request)
        {
            try
            {
                DeliveryTypeSelectModel Result = await _deliveryTypeServices.Update(request);

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
                ListViewModel<DeliveryTypeSelectModel> res = await _deliveryTypeServices.Get(currentPage, filterRequest);

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
                DeliveryTypeSelectModel result = new DeliveryTypeSelectModel();
                result = await _deliveryTypeServices.GetById(id);

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
                DeliveryType result = await _deliveryTypeServices.Delete(id);
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
