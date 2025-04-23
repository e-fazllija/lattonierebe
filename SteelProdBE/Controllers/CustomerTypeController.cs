using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.TypologiesModels.CustomerTypeModels;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CustomerTypeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerTypeServices _customerTypeServices;
        private readonly ILogger<CustomerTypeController> _logger;

        public CustomerTypeController(
            IConfiguration configuration,
            ICustomerTypeServices customerTypeServices,
             ILogger<CustomerTypeController> logger)
        {
            _configuration = configuration;
            _customerTypeServices = customerTypeServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CustomerTypeCreateModel request)
        {
            try
            {
                CustomerTypeSelectModel Result = await _customerTypeServices.Create(request);
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
        public async Task<IActionResult> Update(CustomerTypeUpdateModel request)
        {
            try
            {
                CustomerTypeSelectModel Result = await _customerTypeServices.Update(request);

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
                ListViewModel<CustomerTypeSelectModel> res = await _customerTypeServices.Get(currentPage, filterRequest);

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
                CustomerTypeSelectModel result = new CustomerTypeSelectModel();
                result = await _customerTypeServices.GetById(id);

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
                CustomerType result = await _customerTypeServices.Delete(id);
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
