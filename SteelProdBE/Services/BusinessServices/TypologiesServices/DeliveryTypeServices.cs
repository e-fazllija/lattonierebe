using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.AccessoryTypeModels;
using SteelProdBE.Models.TypologiesModels.DeliveryTypeModels;

namespace SteelProdBE.Services.BusinessServices.TypologiesServices
{
    public class DeliveryTypeServices : IDeliveryTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DeliveryTypeServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public DeliveryTypeServices(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeliveryTypeServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _configuration = configuration;
            _logger = logger;
            this.options = options;

        }

        public async Task<DeliveryTypeSelectModel> Create(DeliveryTypeCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<DeliveryType>(dto);
                await _unitOfWork.DeliveryTypeRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                DeliveryTypeSelectModel response = new DeliveryTypeSelectModel();
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

        public async Task<DeliveryType> Delete(int id)
        {
            try
            {
                var query = await _unitOfWork.DeliveryTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                DeliveryType EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.DeliveryTypeRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<DeliveryTypeSelectModel>> Get(int currentPage, string? filterRequest)
        {
            try
            {
                var query = await _unitOfWork.DeliveryTypeRepository.GetIQuerableListAsync();

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest));

                ListViewModel<DeliveryTypeSelectModel> result = new ListViewModel<DeliveryTypeSelectModel>();

                List<DeliveryType> EntityClasses = await query.ToListAsync();
                result.Total = await query.CountAsync();

                if (EntityClasses == null)
                    return new ListViewModel<DeliveryTypeSelectModel>();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.AccessoryItemPerPage) - options.CurrentValue.AccessoryItemPerPage)
                            .Take(options.CurrentValue.AccessoryItemPerPage);
                }

                result.Data = _mapper.Map<List<DeliveryTypeSelectModel>>(EntityClasses);

                _logger.LogInformation(nameof(Get));

                return result;
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
                    throw new Exception("Si è verificato un errore");
                }
            }
        }

        public async Task<DeliveryTypeSelectModel> GetById(int id)
        {
            try
            {
                var query = await _unitOfWork.DeliveryTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                DeliveryTypeSelectModel result = new DeliveryTypeSelectModel();

                DeliveryType EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    return result;

                _mapper.Map(EntityClasses, result);

                _logger.LogInformation(nameof(GetById));

                return result;
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
                    throw new Exception("Si è verificato un errore");
                }
            }
        }

        public async Task<DeliveryTypeSelectModel> Update(DeliveryTypeUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.DeliveryTypeRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.DeliveryTypeRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                DeliveryTypeSelectModel response = new DeliveryTypeSelectModel();
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
