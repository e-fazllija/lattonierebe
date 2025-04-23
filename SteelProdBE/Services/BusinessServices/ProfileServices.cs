using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.ProfileModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class ProfileServices : IProfileServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfileServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public ProfileServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProfileServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }
        public async Task<ProfileSelectModel> Create(ProfileCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Entities.Profile>(dto);
                await _unitOfWork.ProfileRepository.InsertAsync(entityClass);
                _unitOfWork.Save();


                ProfileSelectModel response = new ProfileSelectModel();
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

        public async Task<Entities.Profile> Delete(int id)
        {
            try
            {
                IQueryable<Entities.Profile> query = _unitOfWork.dbContext.Profiles;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                
                Entities.Profile EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Record non trovato!");

                _unitOfWork.ProfileRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<ProfileSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Entities.Profile> query = _unitOfWork.dbContext.Profiles;

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

                ListViewModel<ProfileSelectModel> result = new ListViewModel<ProfileSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.ProfileItemPerPage) - options.CurrentValue.ProfileItemPerPage)
                            .Take(options.CurrentValue.ProfileItemPerPage);
                }

                List<Entities.Profile> queryList = await query
                    .Include(x => x.ProfileType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType).ToListAsync();

                result.Data = _mapper.Map<List<ProfileSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<ProfileSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.Profiles
                    .Include(x => x.ProfileType)
                    .Include(x => x.Supplier)
                    .Include(x => x.DeliveryType)
                    .FirstOrDefaultAsync(x => x.Id == id);

                ProfileSelectModel result = _mapper.Map<ProfileSelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<ProfileSelectModel> Update(ProfileUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.ProfileRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Record non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.ProfileRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                ProfileSelectModel response = new ProfileSelectModel();
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
