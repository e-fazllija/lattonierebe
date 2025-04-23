using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.CustomerTypeModels;
using SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels;

namespace SteelProdBE.Services.BusinessServices.TypologiesServices
{
    public class GoodReceiptTypeServices : IGoodReceiptTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GoodReceiptType> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public GoodReceiptTypeServices(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, ILogger<GoodReceiptType> logger, IOptionsMonitor<PaginationOptions> options)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _configuration = configuration;
            _logger = logger;
            this.options = options;

        }
        public async Task<GoodReceiptTypeSelectModel> Create(GoodReceiptTypeCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<GoodReceiptType>(dto);
                await _unitOfWork.GoodReceiptTypeRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                GoodReceiptTypeSelectModel response = new GoodReceiptTypeSelectModel();
                _mapper.Map(entityClass, response);

                _logger.LogInformation(nameof(Create));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);

            }
        }

        public async Task<GoodReceiptType> Delete(int id)
        {
            try
            {
                var query = await _unitOfWork.GoodReceiptTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                GoodReceiptType EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.GoodReceiptTypeRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<GoodReceiptTypeSelectModel>> Get(int currentPage, string? filterRequest)
        {
            try
            {
                var query = await _unitOfWork.GoodReceiptTypeRepository.GetIQuerableListAsync();

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest));

                ListViewModel<GoodReceiptTypeSelectModel> result = new ListViewModel<GoodReceiptTypeSelectModel>();

                List<GoodReceiptType> EntityClasses = await query.ToListAsync();
                result.Total = await query.CountAsync();

                if (EntityClasses == null)
                    return new ListViewModel<GoodReceiptTypeSelectModel>();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.AccessoryItemPerPage) - options.CurrentValue.AccessoryItemPerPage)
                            .Take(options.CurrentValue.AccessoryItemPerPage);
                }

                result.Data = _mapper.Map<List<GoodReceiptTypeSelectModel>>(EntityClasses);

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

        public async Task<GoodReceiptTypeSelectModel> GetById(int id)
        {
            try
            {
                var query = await _unitOfWork.GoodReceiptTypeRepository.GetIQuerableListAsync();
                if (id != 0)
                    query = query.Where(x => x.Id == id);

                GoodReceiptTypeSelectModel result = new GoodReceiptTypeSelectModel();

                GoodReceiptType EntityClasses = await query.FirstOrDefaultAsync();

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

        public async Task<GoodReceiptTypeSelectModel> Update(GoodReceiptTypeUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.GoodReceiptTypeRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Nessun risultato trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.GoodReceiptTypeRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                GoodReceiptTypeSelectModel response = new GoodReceiptTypeSelectModel();
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
