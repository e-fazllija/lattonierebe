using AutoMapper;
using Carpenteria.Api.Services.BusinessServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.SupplierModels;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class SupplierServices: ISupplierServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public SupplierServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SupplierServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }

        public async Task<SupplierSelectModel> Create(SupplierCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<Supplier>(dto);
                await _unitOfWork.SupplierRepository.InsertAsync(entityClass);
                _unitOfWork.Save();

                SupplierSelectModel response = _mapper.Map<SupplierSelectModel>(entityClass);

                _logger.LogInformation(nameof(Create));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore in fase creazione");
            }
        }

        public async Task<SupplierSelectModel> Update(SupplierUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.SupplierRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.SupplierRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                SupplierSelectModel response = new SupplierSelectModel();
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

        public async Task<ListViewModel<SupplierSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName)
        {
            try
            {
                IQueryable<Supplier> query = _unitOfWork.dbContext.Suppliers;

                if (!string.IsNullOrEmpty(filterRequest))
                    query = query.Where(x => x.Name.Contains(filterRequest) || x.Code.Contains(filterRequest));

                if (fromName != null && !char.IsLetter(fromName ?? ' '))
                    query = query.Where(x => x.Name.Length > 0 && x.Name[0] >= fromName);

                if (toName != null && !char.IsLetter(toName ?? ' '))
                    query = query.Where(x => x.Name.Length > 0 && x.Name[0] <= toName);

                ListViewModel<SupplierSelectModel> result = new ListViewModel<SupplierSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.SupplierItemPerPage) - options.CurrentValue.SupplierItemPerPage)
                            .Take(options.CurrentValue.SupplierItemPerPage);
                }

                List<Supplier> queryList = await query
                    .Include(x => x.PaymentType).ToListAsync();

                result.Data = _mapper.Map<List<SupplierSelectModel>>(queryList);

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }

        }

        public async Task<SupplierSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                var query = await _unitOfWork.dbContext.Suppliers
                    .Include(x => x.PaymentType)
                    .FirstOrDefaultAsync(x => x.Id == id);

                SupplierSelectModel result = _mapper.Map<SupplierSelectModel>(query);

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<Supplier> Delete(int id)
        {
            try
            {
                IQueryable<Supplier> query = _unitOfWork.dbContext.Suppliers;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                Supplier EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                _unitOfWork.SupplierRepository.Delete(EntityClasses);
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
