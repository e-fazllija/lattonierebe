using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.MaterialModels;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MaterialServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public MaterialServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MaterialServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }
        public async Task<MaterialSelectModel> Create(MaterialCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Material>(dto);
                await _unitOfWork.MaterialRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                MaterialSelectModel response = new MaterialSelectModel();
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

        public async Task<Material> Delete(int id)
        {
            try
            {
                IQueryable<Material> query = _unitOfWork.dbContext.Materials;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                Material EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.MaterialRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<MaterialSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Material> query = _unitOfWork.dbContext.Materials;

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest));

                if (fromName != null)
                {
                    string fromNameString = fromName.ToString();
                    query = query.Where(x => string.Compare(x.Name.Substring(0, 1), fromNameString) >= 0);
                }

                if (toName != null)
                {
                    string toNameString = toName.ToString();
                    query = query.Where(x => string.Compare(x.Name.Substring(0, 1), toNameString) <= 0);
                }

                ListViewModel<MaterialSelectModel> result = new ListViewModel<MaterialSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.MaterialItemPerPage) - options.CurrentValue.MaterialItemPerPage)
                            .Take(options.CurrentValue.MaterialItemPerPage);
                }

                List<Material> queryList = await query
                    .Include(x => x.MaterialType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType).ToListAsync();

                result.Data = _mapper.Map<List<MaterialSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<MaterialSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.Materials
                    .Include(x => x.MaterialType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType)
                    .FirstOrDefaultAsync(x => x.Id == id);

                MaterialSelectModel result = _mapper.Map<MaterialSelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<MaterialSelectModel> Update(MaterialUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.MaterialRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.MaterialRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                MaterialSelectModel response = new MaterialSelectModel();
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
    }
}
