using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.ModuleXmlModels;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;
using System.Xml.Linq;
using org.matheval;
using SteelProdBE.Models.XmlFileListModels;
using SteelProdBE.Models.MarkingModels;
using SteelProdBE.Models.Xml;
using System.Reflection;

namespace SteelProdBE.Services.BusinessServices
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public OrdersServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrdersServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }
        public async Task<XmlOperaSelectModel> Create(XmlOperaCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<XmlOpera>(dto);

                await _unitOfWork.XmlOperaRepository.InsertAsync(entityClass);
                _unitOfWork.Save();

                XmlOperaSelectModel response = new XmlOperaSelectModel();
                _mapper.Map(entityClass, response);

                _logger.LogInformation(nameof(Create));
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore in fase creazione");
            }
        }

        public async Task<XmlOpera> Delete(int id)
        {
            try
            {
                IQueryable<XmlOpera> query = _unitOfWork.dbContext.XmlOpera;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                XmlOpera EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.XmlOperaRepository.Delete(EntityClasses);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation(nameof(Delete));

                return EntityClasses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException.Message.Contains("DELETE statement conflicted with the REFERENCE constraint"))
                {
                    throw new Exception("Impossibile eliminare il record perché è utilizzato come chiave esterna in un'altra tabella.");
                }
                if (ex is NullReferenceException)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception("Si è verificato un errore in fase di eliminazione");
                }
            }
        }

        public async Task<ListViewModel<XmlOperaSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<XmlOpera> query = _unitOfWork.dbContext.XmlOpera;

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Job.job_name.Contains(filterRequest)); 

                if (fromName != null)
                {
                    string fromNameString = fromName.ToString();
                    query = query.Where(x => string.Compare(x.Job.job_name.Substring(0, 1), fromNameString) >= 0);
                }

                if (toName != null)
                {
                    string toNameString = toName.ToString();
                    query = query.Where(x => string.Compare(x.Job.job_name.Substring(0, 1), toNameString) <= 0);
                }

                ListViewModel<XmlOperaSelectModel> result = new ListViewModel<XmlOperaSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.MaterialItemPerPage) - options.CurrentValue.MaterialItemPerPage)
                            .Take(options.CurrentValue.MaterialItemPerPage);
                }

                List<XmlOpera> queryList = await query.OrderByDescending(x => x.Id).Include(x => x.Job).ThenInclude(x => x.OperaJobCustomer).ToListAsync();


                result.Data = _mapper.Map<List<XmlOperaSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<XmlOperaSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                 var query = await _unitOfWork.dbContext.XmlOpera.Include(x => x.Job).ThenInclude(x => x.OperaJobCustomer).FirstOrDefaultAsync(x => x.Id == id);

                XmlOperaSelectModel result = _mapper.Map<XmlOperaSelectModel>(query);

                 _logger.LogInformation(nameof(GetById));
                
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<XmlOperaSelectModel> Update(XmlOperaUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.XmlOperaRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.XmlOperaRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                XmlOperaSelectModel response = new XmlOperaSelectModel();
                _mapper.Map(EntityClass, response);

                _logger.LogInformation(nameof(Update));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex is NullReferenceException)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception("Si è verificato un errore in fase di modifica");
                }
            }
        }

        #region "XmlFileList"

        public async Task<List<XElement>> CreateXmlFileList(XmlFileListCreateModel dto)
        {
            if (string.IsNullOrEmpty(dto.customer))
                dto.customer = "Default";
                //throw new NullReferenceException("Errore cst_name. Non è stato trovato nessun riferimento al tag");

            List<XElement> listXml = new List<XElement>();
            string condition_IdCode = "";
            string condition_MatName = "";
            int counter = 1;
            string matName = "";
            int jobCounter = 1;
            bool _continue = false;
            var FileList = new XElement("lista_pezzi", new XAttribute("id", $"ID00{jobCounter}"), new XAttribute("ver", "1.3.0"));
            Dictionary<string, (string pieceMatColor, string matColor)> colorMappings = new Dictionary<string, (string, string)>
                        {
                            { "MATERIALE ZINCATO", ("-ZN", "ZN") },
                            { "MATERIALE DECAPATO", ("-DC", "DC") },
                        };

            try
            {
                foreach (var mat in dto.materials)
                {
                    foreach (var cut in mat.xmlCuts)
                    {
                        if (!String.IsNullOrEmpty(matName) && matName != mat.mat_name)
                        {
                            if (FileList.HasElements)
                                listXml.Add(FileList);
                            jobCounter++;
                            matName = mat.mat_name;
                            _continue = true;
                        }
                        else
                        {
                            matName = mat.mat_name;
                        }

                        if (_continue)
                        {
                            FileList = new XElement("lista_pezzi", new XAttribute("id", $"ID00{jobCounter}"), new XAttribute("ver", "1.3.0"));
                            _continue = false;
                        }

                        if (mat.mat_name == condition_MatName && cut.cut_idcode == condition_IdCode)
                            counter++;
                        else
                            counter = 1;

                        (string pieceMatColor, string matColor) = colorMappings.TryGetValue(mat.col_name ?? "", out var colors) ? colors : ("", "");

                        XElement piece = new XElement("pezzo", new XAttribute("nome", $"{mat.mat_name}{pieceMatColor}-{cut.cut_idcode.Replace(".", "-")}-{counter}"), new XAttribute("macc", "2720"), new XAttribute("lung", $"{cut.cut_lenght_external}"), new XAttribute("pw", "0"), new XAttribute("outDir", $"\\\\Serverproliant3\\d\\Blm Pro\\opera"), new XAttribute("um", "mm"));

                        if (cut.xmlMachinings.Count > 0)
                            FileList.Add(piece);

                        condition_MatName = mat.mat_name;
                        condition_IdCode = cut.cut_idcode;

                        XElement modules = new XElement("moduli");
                        if (cut.xmlMachinings.Count > 0)
                            piece.Add(modules);

                        if (await _unitOfWork.MarkingRepository.AnyAsync(x => x.MaterialName == mat.mat_name))
                        {
                            var marking = await GetMarking(mat.mat_name, cut.cut_lenght_external, cut.cut_idcode.Replace(",", "."));

                            XElement markings = new XElement("marcature", new XElement("marcatura", new XAttribute("idFac", marking.IdFac), new XAttribute("dx", marking.Dx), new XAttribute("dy", marking.Dy), new XAttribute("lung", marking.Lung), new XAttribute("larg", marking.Larg), new XAttribute("str", marking.Str.Replace(",", "."))));
                            piece.Add(marking);
                        }
                        foreach (var m in cut.xmlMachinings)
                        {
                            ModuleFileList Mach = await GetMach(new ModuleFileList()
                            {
                                Name = m.mach_name,
                                Cut_length_external = Double.Parse(cut.cut_lenght_external),
                                CutIdCode = cut.cut_idcode,
                                Customer = dto.customer,
                                MatName = mat.mat_name,
                                MatColor = matColor ?? "",
                                Model = dto.cmp_panes
                            });
                            if (Mach.LoopCutIdCode)
                            {
                                char[] splitIdCode = cut.cut_idcode.Replace(".", " ").ToArray();

                                for (int index = 0; index < Mach.CutIdCodeLenght; index++)
                                {
                                    char splitChar = splitIdCode[index];
                                    string name = $"{Mach.CutNameStart}{splitChar}{(splitChar == ' ' ? "" : Mach.CutNameEnd)}";

                                    XElement module = new XElement("modulo", new XAttribute("nome", name), new XAttribute("dx", Mach.DeltaX.Replace(",", ".")), new XAttribute("da", Mach.Da.Replace(",", ".")), new XAttribute("nRip", Mach.NRip.Replace(",", ".")), new XAttribute("dxRip", Mach.DxRip.Replace(",", ".")), new XAttribute("daRip", "0"), new XAttribute("nRipA", "0"), new XAttribute("daRipA", "0"));
                                    modules.Add(module);

                                    if (Mach.AvanzamentoDeltaX.Contains('-'))
                                        Mach.DeltaX = Convert.ToString(Convert.ToDouble(Mach.DeltaX) - Convert.ToDouble(Mach.AvanzamentoDeltaX.Replace("-", "")));
                                    else if (Mach.AvanzamentoDeltaX.Contains('+'))
                                        Mach.DeltaX = Convert.ToString(Convert.ToDouble(Mach.DeltaX) + Convert.ToDouble(Mach.AvanzamentoDeltaX.Replace("+", "")));
                                    else if (Mach.AvanzamentoDeltaX.Contains('*'))
                                        Mach.DeltaX = Convert.ToString(Convert.ToDouble(Mach.DeltaX) * Convert.ToDouble(Mach.AvanzamentoDeltaX.Replace("*", "")));
                                    else if (Mach.AvanzamentoDeltaX.Contains('/'))
                                        Mach.DeltaX = Convert.ToString(Convert.ToDouble(Mach.DeltaX) / Convert.ToDouble(Mach.AvanzamentoDeltaX.Replace("/", "")));
                                    else
                                        Mach.DeltaX = Convert.ToString(Convert.ToDouble(Mach.DeltaX) + Convert.ToDouble(Mach.AvanzamentoDeltaX));
                                }
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(Mach.Name))
                                {
                                    XElement module = new XElement("modulo", new XAttribute("nome", Mach.Name), new XAttribute("dx", Mach.Dx.Replace(",", ".")), new XAttribute("da", Mach.Da.Replace(",", ".")), new XAttribute("nRip", Mach.NRip.Replace(",", ".")), new XAttribute("dxRip", Mach.DxRip.Replace(",", ".")), new XAttribute("daRip", "0"), new XAttribute("nRipA", "0"), new XAttribute("daRipA", "0"));
                                    modules.Add(module);
                                }
                            }
                        }
                    }
                }
                listXml.Add(FileList);
                return listXml;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex is NullReferenceException || ex is ArgumentException)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception("Si è verificato un errore");
                }

            }
        }

        private async Task<MarkingSelectModel> GetMarking(string matName, string cut_lenght_external, string cutIdCode)
        {
            try
            {
                MarkingSelectModel marking = new MarkingSelectModel();
                var query = await _unitOfWork.MarkingRepository.GetIQuerableListAsync();
                query = query.Where(x => x.MaterialName == matName);

                if (query.Any(x => Convert.ToDouble(x.From) < Double.Parse(cut_lenght_external)) &&
                        query.Any(x => Convert.ToDouble(x.To) >= Double.Parse(cut_lenght_external)))
                {
                    query = query.Where(x => Convert.ToDouble(x.From) < Double.Parse(cut_lenght_external) && Convert.ToDouble(x.To) >= Double.Parse(cut_lenght_external));
                }

                Marking entity = await query.FirstOrDefaultAsync();
                if (entity == null)
                    throw new ArgumentException($"Non esiste una marcatura associata al materiale {matName}");

                _mapper.Map(entity, marking);

                Expression Dx = new Expression(marking.Dx.Replace("l", cut_lenght_external).Replace("i", cutIdCode));
                Expression IdFac = new Expression(marking.IdFac.Replace("l", cut_lenght_external).Replace("i", cutIdCode));
                Expression Dy = new Expression(marking.Dy.Replace("l", cut_lenght_external).Replace("i", cutIdCode));
                Expression Lung = new Expression(marking.Lung.Replace("l", cut_lenght_external).Replace("i", cutIdCode));
                Expression Larg = new Expression(marking.Larg.Replace("l", cut_lenght_external).Replace("i", cutIdCode));
                Expression Str = new Expression(marking.Str.Replace("l", cut_lenght_external).Replace("i", cutIdCode));

                marking.Dx = CheckExpression(marking.Dx) ? Eval(Dx, marking.Id , "Dx") : marking.Dx;
                marking.IdFac = CheckExpression(marking.IdFac) ? Eval(IdFac, marking.Id, "Dx") : marking.IdFac;
                marking.Dy = CheckExpression(marking.Dy) ? Eval(Dy, marking.Id, "Dx") : marking.Dy;
                marking.Lung = CheckExpression(marking.Lung) ? Eval(Lung, marking.Id, "Dx") : marking.Lung;
                marking.Larg = CheckExpression(marking.Larg) ? Eval(Larg, marking.Id, "Dx") : marking.Larg;
                marking.Str = CheckExpression(marking.Str) ? Eval(Str, marking.Id, "Dx") : marking.Str;

                return marking;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex is NullReferenceException || ex is ArgumentException)
                {
                    throw new NullReferenceException("Errore marcatura: " + ex.Message);
                }
                else
                {
                    throw new ArgumentException($"Si è verificato un errore");
                }

            }
        }

        private async Task<ModuleFileList> GetMach(ModuleFileList request)
        {
            try
            {
                var entity = await _unitOfWork.ModuleXmlRepository.GetIQuerableListAsync();
                entity = entity.Where(x => x.NameXmlOpera == request.Name);
                List<ModuleXmlSelectModel> modules = new();
                _mapper.Map(entity, modules);
                ModuleXmlSelectModel? module = new ModuleXmlSelectModel();

                if (modules.Count > 1)
                {
                    if (modules.Any(x => x.ByRange && Convert.ToDouble(x.From) < request.Cut_length_external) &&
                        modules.Any(x => x.ByRange && Convert.ToDouble(x.To) >= request.Cut_length_external))
                    {
                        modules = modules.Where(x => Convert.ToDouble(x.From) < request.Cut_length_external && Convert.ToDouble(x.To) >= request.Cut_length_external).ToList();
                    }
                    else
                    {
                        modules = modules.Where(x => !x.ByRange).ToList();
                    }

                    if (modules.Any(x
                        => (x.ByMaterial && x.MaterialName == request.MatName) ||
                        (x.ByCustomer && x.Customer!.ToLower().Contains(request.Customer!.ToLower())) ||
                        (x.ByMaterialColor && x.MaterialColor!.ToLower().Contains(request.MatColor!.ToLower()) && !string.IsNullOrEmpty(request.MatColor)) ||
                        (x.ByModel && x.Model!.ToLower().Contains(request.Model!.ToLower()) && !string.IsNullOrEmpty(request.Model))))
                    {
                        if (modules.Any(x => x.ByCustomer && x.Customer!.ToLower().Contains(request.Customer!.ToLower())))
                            modules = modules.Where(x => x.ByCustomer && x.Customer!.Contains(request.Customer!)).ToList();

                        if (modules.Any(x => x.ByMaterial && x.MaterialName == request.MatName))
                            modules = modules.Where(x => x.ByMaterial && x.MaterialName == request.MatName).ToList();

                        if (modules.Any(x => x.ByMaterialColor && x.MaterialColor.ToLower().Contains(request.MatColor.ToLower())))
                            modules = modules.Where(x => x.ByMaterialColor && x.MaterialColor.ToLower().Contains(request.MatColor.ToLower())).ToList();

                        if (modules.Any(x => x.ByModel && x.Model.ToLower().Contains(request.Model.ToLower())))
                            modules = modules.Where(x => x.ByModel && x.Model.ToLower().Contains(request.Model.ToLower())).ToList();

                        module = modules.FirstOrDefault();
                    }
                    else
                    {
                        module = modules.Where(x => !x.ByCustomer && !x.ByMaterial && !x.ByMaterialColor && !x.ByModel).FirstOrDefault()!;
                    }

                }
                else if (modules.Count == 1)
                {
                    module = modules.FirstOrDefault()!;
                }

                if (module == null)
                    return new ModuleFileList();


                ModuleFileList result = new ModuleFileList();

                Expression NRip = new Expression(module.NRip.Replace(",", ".")).Bind("l", request.Cut_length_external);
                string nRipRes = CheckExpression(module.NRip) ? Eval(NRip, module.Id, "NRip") : module.NRip;
                result.NRip = RoundCeil(nRipRes, module.RoundNRip, module.CeilNRip, false, module.NameXmlOpera);

                Expression Dx = new Expression(module.Dx.Replace(",", ".")).Bind("l", request.Cut_length_external).Bind("n", double.Parse(result.NRip));
                string dxRes = CheckExpression(module.Dx) ? Eval(Dx, module.Id, "Dx") : module.Dx;
                result.Dx = RoundCeil(dxRes, module.RoundDx, module.CeilDx, true, module.NameXmlOpera);

                Expression Da = new Expression(module.Da.Replace(",", ".")).Bind("l", request.Cut_length_external).Bind("n", double.Parse(result.NRip));
                string daRes = CheckExpression(module.Da) ? Eval(Da, module.Id, "Da") : module.Da;
                result.Da = RoundCeil(daRes, module.RoundDa, module.CeilDa, true, module.NameXmlOpera);

                Expression DxRip = new Expression(module.DxRip.Replace(",", ".")).Bind("l", request.Cut_length_external).Bind("n", double.Parse(result.NRip));
                string dxRipRes = CheckExpression(module.DxRip) ? Eval(DxRip, module.Id, "DxRip") : module.DxRip;
                result.DxRip = RoundCeil(dxRipRes, module.RoundDxRip, module.CeilDxRip, true, module.NameXmlOpera);

                Expression DeltaX = !string.IsNullOrEmpty(module.DeltaX) ?
                    new Expression(module.DeltaX.Replace(",", ".")).Bind("l", request.Cut_length_external).Bind("n", double.Parse(result.NRip)) : null!;

                string? deltaX = !string.IsNullOrEmpty(module.DeltaX) ? (CheckExpression(module.DeltaX) ? Eval(DeltaX, module.Id, "DeltaX") : module.DeltaX) : null;
                result.DeltaX = deltaX;

                result.Name = module.Name;
                result.Cut_length_external = request.Cut_length_external;
                result.LoopCutIdCode = module.LoopCutIdCode;
                result.CutIdCodeLenght = !string.IsNullOrEmpty(module.DeltaX) || module.DeltaX == "0" ? request.CutIdCode.Length : 0;
                result.AvanzamentoDeltaX = module.AvanzamentoDeltaX;
                result.CutNameStart = module.CutNameStart;
                result.CutNameEnd = module.CutNameEnd;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex is NullReferenceException || ex is ArgumentException)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new ArgumentException($"Si è verificato un errore durante la generazione del module {request.Name}");
                }

            }

        }

        private string RoundCeil(string val, bool round, bool ceil, bool dec, string operaName)
        {
            if (round)
            {
                var valToDecimal = Convert.ToDecimal(val);
                var roundRes = Math.Floor(valToDecimal);
                double res = Convert.ToDouble(roundRes);
                return res > 0 && dec ? res.ToString("0.000") : res.ToString();
            }
            else if (ceil)
            {
                double res = Convert.ToDouble(Math.Ceiling(Convert.ToDecimal(val)));
                return res > 0 && dec ? res.ToString("0.000") : res.ToString();
            }
            else
            {
                double res = Convert.ToDouble(val);
                return res > 0 && dec ? res.ToString("0.000") : res.ToString();
            }
        }

        private bool CheckExpression(string expression)
        {
            char[] calc = { '+', '-', '*', '/' };
            return !calc.Any(c => expression.StartsWith(c));
        }

        private string Eval(Expression expression, int moduleId, string formula)
        {
            try
            {
                string value = expression.Eval().ToString()!;
                return value;
            }
            catch (Exception)
            {
                throw new NullReferenceException($"Si è verificato un errore nel calcolo della formura associata al {formula} nel module {moduleId}");
            }
        }
        public async Task<XmlFileListCreateModel> GetDataForXmlFile(int id)
        {
            try
            {
                var query = await _unitOfWork.XmlOperaRepository.GetIQuerableListAsync(x => x.Where(x => x.Id == id));

                var xmlFileList = await query.Include("Job.OperaJobCustomer")
                                .Include("Job.OperaJobComponents.OperaComponent")
                                .Include("Job.OperaMaterials.OperaMaterial.OperaMaterialColors.OperaMaterialColor")
                                .Include("Job.OperaMaterials.OperaMaterial.OperaCuts.OperaCut.OperaMachinings.OperaMachining")
                                .Select(x => new XmlFileListCreateModel
                                {
                                    job_id = x.Job.job_id,
                                    job_name = x.Job.job_name,
                                    customer = x.Job!.OperaJobCustomer!.cst_name,
                                    cmp_panes = x.Job!.OperaJobComponents!.OperaComponent
                                        .OrderBy(c => c.Id)
                                        .FirstOrDefault(c => !string.IsNullOrEmpty(c.cmp_panes))!.cmp_panes,
                                    materials = x.Job.OperaMaterials.OperaMaterial
                                        .Select(mat => new XmlFileListMaterialCreateModel
                                        {
                                            mat_name = mat.mat_name,
                                            col_name = mat.OperaMaterialColors.OperaMaterialColor
                                                .Select(col => col.col_name).FirstOrDefault(),
                                            xmlCuts = mat.OperaCuts.OperaCut.Select(cuts => new XmlFileListCutCreateModel
                                            {
                                                cut_idcode = cuts.cut_idcode,
                                                cut_lenght_external = cuts.cut_lenght_external,
                                                machiningsCheck = string.Join("", cuts.OperaMachinings.OperaMachining.Select(x => x.mach_name)),
                                                xmlMachinings = cuts.OperaMachinings.OperaMachining.Select(mach => new XmlFileListMachiningsCreateModel
                                                {
                                                    mach_name = mach.mach_name
                                                }).ToList()
                                            }).OrderBy(cuts => cuts.cut_idcode)
                                            .ToList()
                                        }).Where(mat => _unitOfWork.dbContext.ProfilesXml.Any(prof => prof.Name == mat.mat_name)).ToList()
                                })
                                .FirstOrDefaultAsync();

                if (xmlFileList.materials.Any(mat => mat.mat_name == "OVALINA"))
                {
                    var material = xmlFileList.materials.Where(mat => mat.mat_name == "OVALINA").FirstOrDefault();
                    material.xmlCuts = material.xmlCuts.DistinctBy(mat => mat.cut_idcode).ToList();

                    int quantity = xmlFileList.materials.RemoveAll(mat => mat.mat_name == "OVALINA");
                    xmlFileList.materials.Add(material);
                }

                if (xmlFileList.materials.Any(mat => mat.mat_name == "40-30"))
                {
                    var material = xmlFileList.materials.Where(mat => mat.mat_name == "40-30").FirstOrDefault();
                    material.xmlCuts = material.xmlCuts.DistinctBy(mat => mat.cut_idcode).ToList();
                    int quantity = xmlFileList.materials.RemoveAll(mat => mat.mat_name == "40-30");
                    xmlFileList.materials.Add(material);
                }

                if (xmlFileList == null)
                    throw new NullReferenceException("Xml non trovato");

                _logger.LogInformation(nameof(GetDataForXmlFile));

                return xmlFileList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex is NullReferenceException || ex is ArgumentException)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception("Si è verificato un errore");
                }
            }
        }


        #endregion
    }
}
