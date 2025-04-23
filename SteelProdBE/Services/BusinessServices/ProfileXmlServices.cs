using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ProfileXmlModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class ProfileXmlServices : IProfileXmlServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfileXmlServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public ProfileXmlServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProfileXmlServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }
        public async Task<ProfileXmlSelectModel> Create(ProfileXmlCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Entities.ProfileXml>(dto);
                await _unitOfWork.ProfileXmlRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                ProfileXmlSelectModel response = new ProfileXmlSelectModel();
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

        public async Task<Entities.ProfileXml> Delete(int id)
        {
            try
            {
                IQueryable<Entities.ProfileXml> query = _unitOfWork.dbContext.ProfilesXml;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                
                Entities.ProfileXml EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.ProfileXmlRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<ProfileXmlSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Entities.ProfileXml> query = _unitOfWork.dbContext.ProfilesXml;

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

                ListViewModel<ProfileXmlSelectModel> result = new ListViewModel<ProfileXmlSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.ProfileXmlItemPerPage) - options.CurrentValue.ProfileXmlItemPerPage)
                            .Take(options.CurrentValue.ProfileXmlItemPerPage);
                }

                List<Entities.ProfileXml> queryList = await query.ToListAsync();

                result.Data = _mapper.Map<List<ProfileXmlSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<ProfileXmlSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.ProfilesXml
                    .FirstOrDefaultAsync(x => x.Id == id);

                ProfileXmlSelectModel result = _mapper.Map<ProfileXmlSelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<ProfileXmlSelectModel> Update(ProfileXmlUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.ProfileXmlRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.ProfileXmlRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                ProfileXmlSelectModel response = new ProfileXmlSelectModel();
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
