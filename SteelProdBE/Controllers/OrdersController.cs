using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.CustomerModels;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ResponseModel;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;
using SteelProdBE.Services;
using SteelProdBE.Services.BusinessServices;
using System.Data;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SteelProdBE.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _ordersServices;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IOrdersServices ordersServices, ILogger<OrdersController> logger)
        {
            _ordersServices = ordersServices;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(InsertOperaXml))]
        public async Task<IActionResult> InsertOperaXml(IFormFile file)
        {
            try
            {
                var stream = file.OpenReadStream();
                XmlSerializer reader = new XmlSerializer(typeof(XmlOperaCreateModel));

                XmlOperaCreateModel xmlOpera = (XmlOperaCreateModel)reader.Deserialize(stream)!;
                XmlOperaSelectModel result = await _ordersServices.Create(xmlOpera);

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update(XmlOperaUpdateModel request)
        {
            try
            {
                XmlOperaSelectModel Result = await _ordersServices.Update(request);

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
                ListViewModel<XmlOperaSelectModel> res = await _ordersServices.Get(currentPage, filterRequest, null, null);

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
                XmlOperaSelectModel result = new XmlOperaSelectModel();
                result = await _ordersServices.GetById(id);

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
                XmlOpera result = await _ordersServices.Delete(id);
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
                var result = await _ordersServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<XmlOperaSelectModel>(result.Data);
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
                var result = await _ordersServices.Get(0, null, fromName, toName);
                DataTable table = Export.ToDataTable<XmlOperaSelectModel>(result.Data);
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
        [Route(nameof(CreateXmlFileList))]
        public async Task<IActionResult> CreateXmlFileList(int id)
        {
            try
            {
                List<byte[]> bytes = new List<byte[]>();
                var dto = await _ordersServices.GetDataForXmlFile(id);
                List<XElement> FileList = await _ordersServices.CreateXmlFileList(dto);
                foreach (var file in FileList)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        XmlWriterSettings xws = new XmlWriterSettings();
                        xws.OmitXmlDeclaration = true;
                        xws.Indent = true;
                        xws.ConformanceLevel = ConformanceLevel.Auto;

                        using (XmlWriter xw = XmlWriter.Create(ms, xws))
                        {
                            file.WriteTo(xw);
                        }
                        bytes.Add(ms.ToArray());
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        int counter = 1;
                        foreach (var file in bytes)
                        {
                            var entry = archive.CreateEntry($"{dto.job_name}_{counter}.xml", CompressionLevel.Fastest);
                            using (var zipStream = entry.Open())
                            {
                                zipStream.Write(file, 0, file.Length);
                            }
                            counter++;
                        }
                    }

                    byte[] byteArray = ms.ToArray();
                    _logger.LogInformation("Xml created");

                    return new FileContentResult(byteArray, "application/zip");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseModel() { Status = "Error", Message = ex.Message });
            }
        }
    }
}
