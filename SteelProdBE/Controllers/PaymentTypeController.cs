using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.TypologiesModels.PaymentTypeModels;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class PaymentTypeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentTypeServices _paymentTypeServices;
        private readonly ILogger<PaymentTypeController> _logger;

        public PaymentTypeController(
            IConfiguration configuration,
            IPaymentTypeServices paymentTypeServices,
             ILogger<PaymentTypeController> logger)
        {
            _configuration = configuration;
            _paymentTypeServices = paymentTypeServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(PaymentTypeCreateModel request)
        {
            try
            {
                PaymentTypeSelectModel Result = await _paymentTypeServices.Create(request);
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
        public async Task<IActionResult> Update(PaymentTypeUpdateModel request)
        {
            try
            {
                PaymentTypeSelectModel Result = await _paymentTypeServices.Update(request);

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
                ListViewModel<PaymentTypeSelectModel> res = await _paymentTypeServices.Get(currentPage, filterRequest);

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
                PaymentTypeSelectModel result = new PaymentTypeSelectModel();
                result = await _paymentTypeServices.GetById(id);

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
                PaymentType result = await _paymentTypeServices.Delete(id);
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
