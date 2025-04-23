using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.CustomerTypeModels;

namespace SteelProdBE.Services.BusinessServices.TypologiesServices
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerTypeServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public CustomerTypeServices(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerTypeServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _configuration = configuration;
            _logger = logger;
            this.options = options;

        }
        public async Task<CustomerTypeSelectModel> Create(CustomerTypeCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<CustomerType>(dto);
                await _unitOfWork.CustomerTypeRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                CustomerTypeSelectModel response = new CustomerTypeSelectModel();
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

        public async Task<CustomerType> Delete(int id)
        {
            try
            {
                var query = await _unitOfWork.CustomerTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                CustomerType EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.CustomerTypeRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<CustomerTypeSelectModel>> Get(int currentPage, string? filterRequest)
        {
            try
            {
                var query = await _unitOfWork.CustomerTypeRepository.GetIQuerableListAsync();

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest));

                ListViewModel<CustomerTypeSelectModel> result = new ListViewModel<CustomerTypeSelectModel>();

                List<CustomerType> EntityClasses = await query.ToListAsync();
                result.Total = await query.CountAsync();

                if (EntityClasses == null)
                    return new ListViewModel<CustomerTypeSelectModel>();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.AccessoryItemPerPage) - options.CurrentValue.AccessoryItemPerPage)
                            .Take(options.CurrentValue.AccessoryItemPerPage);
                }

                result.Data = _mapper.Map<List<CustomerTypeSelectModel>>(EntityClasses);

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

        public async Task<CustomerTypeSelectModel> GetById(int id)
        {
            try
            {
                var query = await _unitOfWork.CustomerTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                CustomerTypeSelectModel result = new CustomerTypeSelectModel();

                CustomerType EntityClasses = await query.FirstOrDefaultAsync();

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

        public async Task<CustomerTypeSelectModel> Update(CustomerTypeUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.CustomerTypeRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.CustomerTypeRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                CustomerTypeSelectModel response = new CustomerTypeSelectModel();
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
