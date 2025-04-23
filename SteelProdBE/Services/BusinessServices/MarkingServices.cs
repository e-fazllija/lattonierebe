using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Interfaces;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.MarkingModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class MarkingServices : IMarkingServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MarkingServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public MarkingServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MarkingServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;
        }

        public async Task<MarkingSelectModel> Create(MarkingCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Marking>(dto);
                await _unitOfWork.MarkingRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                MarkingSelectModel response = new MarkingSelectModel();
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

        public async Task<MarkingSelectModel> Update(MarkingUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.MarkingRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.MarkingRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                MarkingSelectModel response = new MarkingSelectModel();
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

        public async Task<ListViewModel<MarkingSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Marking> query = _unitOfWork.dbContext.Markings;

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.MaterialName.Contains(filterRequest));

                if (fromName != null)
                {
                    string fromNameString = fromName.ToString();
                    query = query.Where(x => string.Compare(x.MaterialName.Substring(0, 1), fromNameString) >= 0);
                }

                if (toName != null)
                {
                    string toNameString = toName.ToString();
                    query = query.Where(x => string.Compare(x.MaterialName.Substring(0, 1), toNameString) <= 0);
                }

                ListViewModel<MarkingSelectModel> result = new ListViewModel<MarkingSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.MarkingItemPerPage) - options.CurrentValue.MarkingItemPerPage)
                            .Take(options.CurrentValue.MarkingItemPerPage);
                }

                List<Marking> queryList = await query.ToListAsync();

                result.Data = _mapper.Map<List<MarkingSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }

        }

        public async Task<MarkingSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.Markings.FirstOrDefaultAsync(x => x.Id == id);

                MarkingSelectModel result = _mapper.Map<MarkingSelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<Marking> Delete(int id)
        {
            try
            {
                IQueryable<Marking> query = _unitOfWork.dbContext.Markings;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                Marking EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                _unitOfWork.MarkingRepository.Delete(EntityClasses);
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
