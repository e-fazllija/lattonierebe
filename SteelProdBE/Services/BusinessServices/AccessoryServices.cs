using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;

namespace Carpenteria.Api.Services.BusinessServices
{
    public class AccessoryServices : IAccessoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessoryServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public AccessoryServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AccessoryServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }

        public async Task<AccessorySelectModel> Create(AccessoryCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Accessory>(dto);
                await _unitOfWork.AccessoryRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                AccessorySelectModel response = new AccessorySelectModel();
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

        public async Task<AccessorySelectModel> Update(AccessoryUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.AccessoryRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.AccessoryRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                AccessorySelectModel response = new AccessorySelectModel();
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

        public async Task<ListViewModel<AccessorySelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Accessory> query = _unitOfWork.dbContext.Accessories;

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest) || x.Description.Contains(filterRequest));

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

                ListViewModel<AccessorySelectModel> result = new ListViewModel<AccessorySelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.AccessoryItemPerPage) - options.CurrentValue.AccessoryItemPerPage)
                            .Take(options.CurrentValue.AccessoryItemPerPage);
                }

                List<Accessory> queryList = await query
                    .Include(x => x.AccessoryType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType).ToListAsync();

                result.Data = _mapper.Map<List<AccessorySelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }

        }

        public async Task<AccessorySelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.Accessories
                    .Include(x => x.AccessoryType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType)
                    .FirstOrDefaultAsync(x => x.Id == id);

                AccessorySelectModel result = _mapper.Map<AccessorySelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<Accessory> Delete(int id)
        {
            try
            {
                IQueryable<Accessory> query = _unitOfWork.dbContext.Accessories;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                Accessory EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                _unitOfWork.AccessoryRepository.Delete(EntityClasses);
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
    }
}
