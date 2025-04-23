using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.ModuleXmlModels;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Services;
using System.Data;


namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class ModuleXmlController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IModuleXmlServices _moduleXmlServices;
        private readonly ILogger<ModuleXmlController> _logger;

        public ModuleXmlController(
            IConfiguration configuration,
            IModuleXmlServices moduleXmlServices,
             ILogger<ModuleXmlController> logger)
        {
            _configuration = configuration;
            _moduleXmlServices = moduleXmlServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(ModuleXmlCreateModel request)
        {
            try
            {
                ModuleXmlSelectModel Result = await _moduleXmlServices.Create(request);
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
        public async Task<IActionResult> Update(ModuleXmlUpdateModel request)
        {
            try
            {
                ModuleXmlSelectModel Result = await _moduleXmlServices.Update(request);

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
                ListViewModel<ModuleXmlSelectModel> res = await _moduleXmlServices.Get(currentPage, filterRequest, null, null);

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
                ModuleXmlSelectModel result = new ModuleXmlSelectModel();
                result = await _moduleXmlServices.GetById(id);

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
                ModuleXml result = await _moduleXmlServices.Delete(id);
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
                var result = await _moduleXmlServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<ModuleXmlSelectModel>(result.Data);
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
                var result = await _moduleXmlServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<ModuleXmlSelectModel>(result.Data);
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
