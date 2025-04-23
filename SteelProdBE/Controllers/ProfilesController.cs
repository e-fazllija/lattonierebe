using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.ProfileModels;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Services;
using System.Data;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class ProfilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<ProfilesController> _logger;

        public ProfilesController(
           IConfiguration configuration,
           IProfileServices profileServices,
            ILogger<ProfilesController> logger)
        {
            _configuration = configuration;
            _profileServices = profileServices;
            _logger = logger;
        }
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(ProfileCreateModel request)
        {
            try
            {
                ProfileSelectModel Result = await _profileServices.Create(request);
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
        public async Task<IActionResult> Update(ProfileUpdateModel request)
        {
            try
            {
                ProfileSelectModel Result = await _profileServices.Update(request);

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
                ListViewModel<ProfileSelectModel> res = await _profileServices.Get(currentPage, filterRequest, null, null);

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
                ProfileSelectModel result = new ProfileSelectModel();
                result = await _profileServices.GetById(id);

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
                Profile result = await _profileServices.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet]
        [Route(nameof(ExportExcel))]
        public async Task<IActionResult> ExportExcel(char? fromName, char? toName)
        {
            try
            {
                var result = await _profileServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<ProfileSelectModel>(result.Data);
                byte[] fileBytes = Export.GenerateExcelContent(table);

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Output.xlsx");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet]
        [Route(nameof(ExportCsv))]
        public async Task<IActionResult> ExportCsv(char? fromName, char? toName)
        {
            try
            {
                var result = await _profileServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<ProfileSelectModel>(result.Data);
                byte[] fileBytes = Export.GenerateCsvContent(table);

                return File(fileBytes, "text/csv", "Output.csv");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
    }
}
