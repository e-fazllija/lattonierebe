using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.GoodReceiptModels;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Services;
using System.Data;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class GoodReceiptController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGoodReceiptServices _goodReceiptServices;
        private readonly ILogger<GoodReceiptController> _logger;

        public GoodReceiptController(
            IConfiguration configuration,
            IGoodReceiptServices goodReceiptServices,
             ILogger<GoodReceiptController> logger)
        {
            _configuration = configuration;
            _goodReceiptServices = goodReceiptServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(GoodReceiptCreateModel request)
        {
            try
            {
                GoodReceiptSelectModel Result = await _goodReceiptServices.Create(request);
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
        public async Task<IActionResult> Update(GoodReceiptUpdateModel request)
        {
            try
            {
                GoodReceiptSelectModel Result = await _goodReceiptServices.Update(request);

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
        public async Task<IActionResult> Get(int currentPage, int? filterRequest)
        {
            try
            {
                ListViewModel<GoodReceiptSelectModel> res = await _goodReceiptServices.Get(currentPage, filterRequest, null, null);

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
                GoodReceiptSelectModel result = new GoodReceiptSelectModel();
                result = await _goodReceiptServices.GetById(id);

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
                GoodReceipt result = await _goodReceiptServices.Delete(id);
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
        public async Task<IActionResult> ExportExcel(DateTime? fromName, DateTime? toName)
        {
            try
            {
                var result = await _goodReceiptServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<GoodReceiptSelectModel>(result.Data);
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
        public async Task<IActionResult> ExportCsv(DateTime? fromName, DateTime? toName)
        {
            try
            {
                var result = await _goodReceiptServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<GoodReceiptSelectModel>(result.Data);
                byte[] fileBytes = Export.GenerateCsvContent(table);

                return File(fileBytes, "text/csv", "Output.csv");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route(nameof(GetStocks))]
        public async Task<IActionResult> GetStocks(int currentPage, string? filterRequest, int typeFilter)
        {
            try
            {
                ListViewModel<GoodModel> res = await _goodReceiptServices.GetStocks(currentPage, filterRequest, typeFilter, null, null);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
    }
}
