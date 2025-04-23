using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Models.GoodReceiptModels;
using SteelProdBE.Models.Options;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Services.BusinessServices
{
    public class GoodReceiptServices : IGoodReceiptServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GoodReceiptServices> _logger;
        private readonly IOptionsMonitor<PaginationOptions> options;
        public GoodReceiptServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GoodReceiptServices> logger, IOptionsMonitor<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this.options = options;

        }

        public async Task<GoodReceiptSelectModel> Create(GoodReceiptCreateModel dto)
        {
            try
            {
                var entityClass = _mapper.Map<GoodReceipt>(dto);

                if (dto.SupplierId == 0)
                {
                    Supplier? supplier = await _unitOfWork.dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == dto.Id);
                    if (supplier == null)
                        throw new NullReferenceException("Selezionare il fornitore");

                    entityClass.SupplierId = supplier.Id;
                }

                await _unitOfWork.GoodReceiptRepository.InsertAsync(entityClass);
                _unitOfWork.Save();

                switch (entityClass.TypeId)
                {
                    case 0:
                        var accessory = await _unitOfWork.dbContext.Accessories.FirstAsync(a => a.Id == entityClass.GoodId);
                        accessory.Quantity = accessory.Quantity != null ? accessory.Quantity + entityClass.Quantity : entityClass.Quantity;
                        _unitOfWork.dbContext.Accessories.Update(accessory);
                        await _unitOfWork.SaveAsync();
                        break;
                    case 1:
                        var profile = await _unitOfWork.dbContext.Profiles.FirstAsync(p => p.Id == entityClass.GoodId);
                        profile.Quantity = profile.Quantity != null ? profile.Quantity + entityClass.Quantity : entityClass.Quantity;
                        _unitOfWork.dbContext.Profiles.Update(profile);
                        await _unitOfWork.SaveAsync();
                        break;
                    case 2:
                        var material = await _unitOfWork.dbContext.Materials.FirstAsync(m => m.Id == entityClass.GoodId);
                        material.Quantity = material.Quantity != null ? material.Quantity + entityClass.Quantity : entityClass.Quantity;
                        _unitOfWork.dbContext.Materials.Update(material);
                        await _unitOfWork.SaveAsync();
                        break;
                    default:
                        break;
                }

                GoodReceiptSelectModel response = new GoodReceiptSelectModel();
                _mapper.Map(entityClass, response);

                _logger.LogInformation(nameof(Create));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if(ex is NullReferenceException)
                {
                    throw new Exception(ex.Message);
                }
                throw new Exception("Si è verificato un errore in fase creazione");
            }
        }

        public async Task<GoodReceiptSelectModel> Update(GoodReceiptUpdateModel dto)
        {
            try
            {
                var EntityClass =
                    await _unitOfWork.GoodReceiptRepository.FirstOrDefaultAsync(q => q.Where(x => x.Id == dto.Id));

                if (EntityClass == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                EntityClass = _mapper.Map(dto, EntityClass);

                _unitOfWork.GoodReceiptRepository.Update(EntityClass);
                await _unitOfWork.SaveAsync();

                GoodReceiptSelectModel response = new GoodReceiptSelectModel();
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

        public async Task<ListViewModel<GoodReceiptSelectModel>> Get(int currentPage, int? filterRequest, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                IQueryable<GoodReceipt> query = _unitOfWork.dbContext.GoodReceipts;

                if (filterRequest != null)
                    query = query.Where(x => x.DocumentNumber == filterRequest);

                if (fromDate != null)
                {
                    query = query.Where(x => x.Date >= fromDate);
                }

                if (toDate != null)
                {
                    query = query.Where(x => x.Date <= toDate);
                }

                ListViewModel<GoodReceiptSelectModel> result = new ListViewModel<GoodReceiptSelectModel>();

                result.Total = await query.CountAsync();

                if (currentPage > 0)
                {
                    query = query
                    .Skip((currentPage * options.CurrentValue.GoodReceiptItemPerPage) - options.CurrentValue.GoodReceiptItemPerPage)
                            .Take(options.CurrentValue.GoodReceiptItemPerPage);
                }

                List<GoodReceipt> queryList = await query
                    .Include(x => x.Supplier).ToListAsync();

                result.Data = _mapper.Map<List<GoodReceiptSelectModel>>(queryList);

                foreach (var item in result.Data)
                {
                    switch (item.TypeId)
                    {
                        case 0:
                            var accessory = await _unitOfWork.dbContext.Accessories.FirstOrDefaultAsync(a => a.Id == item.GoodId);
                            item.Material = MapAccessoryToGoodModal(accessory);
                            break;
                        case 1:
                            var profile = await _unitOfWork.dbContext.Profiles.FirstOrDefaultAsync(p => p.Id == item.GoodId);
                            item.Material = MapProfileToGoodModal(profile);
                            break;
                        case 2:
                            var material = await _unitOfWork.dbContext.Materials.FirstOrDefaultAsync(m => m.Id == item.GoodId);
                            item.Material = MapMaterialToGoodModal(material);
                            break;
                        default:
                            break;
                    }
                }

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }

        }

        public async Task<GoodReceiptSelectModel> GetById(int id)
        {
            try
            {
                if (id is not > 0)
                    throw new Exception("Si è verificato un errore!");

                GoodReceipt query = await _unitOfWork.dbContext.GoodReceipts
                    .Include(x => x.Supplier)
                    .FirstAsync(x => x.Id == id);

                GoodReceiptSelectModel result = _mapper.Map<GoodReceiptSelectModel>(query);

                switch (result.TypeId)
                {
                    case 0:
                        var accessory = await _unitOfWork.dbContext.Accessories.FirstOrDefaultAsync(a => a.Id == result.GoodId);
                        result.Material = MapAccessoryToGoodModal(accessory);
                        break;
                    case 1:
                        var profile = await _unitOfWork.dbContext.Profiles.FirstOrDefaultAsync(p => p.Id == result.GoodId);
                        result.Material = MapProfileToGoodModal(profile);
                        break;
                    case 2:
                        var material = await _unitOfWork.dbContext.Materials.FirstOrDefaultAsync(m => m.Id == result.GoodId);
                        result.Material = MapMaterialToGoodModal(material);
                        break;
                    default:
                        break;
                }

                _logger.LogInformation(nameof(GetById));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }
        }

        public async Task<GoodReceipt> Delete(int id)
        {
            try
            {
                IQueryable<GoodReceipt> query = _unitOfWork.dbContext.GoodReceipts;

                if (id == 0)
                    throw new NullReferenceException("L'id non può essere 0");

                query = query.Where(x => x.Id == id);

                GoodReceipt EntityClasses = await query.FirstOrDefaultAsync();

                if (EntityClasses == null)
                    throw new NullReferenceException("Accessorio non trovato!");

                _unitOfWork.GoodReceiptRepository.Delete(EntityClasses);
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

        public async Task<ListViewModel<GoodModel>> GetStocks(int currentPage, string? filterRequest, int typeFilter, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                ListViewModel<GoodModel> result = new ListViewModel<GoodModel>();

                switch (typeFilter)
                {
                    case 0:
                        IQueryable<Accessory> accessoryQuery = _unitOfWork.dbContext.Accessories;
                        if (!string.IsNullOrEmpty(filterRequest)) accessoryQuery = accessoryQuery.Where(x => x.Name.Contains(filterRequest));
                        if (fromDate != null) accessoryQuery = accessoryQuery.Where(x => x.LastDeliveryDate >= fromDate);
                        if (toDate != null) accessoryQuery = accessoryQuery.Where(x => x.LastDeliveryDate <= toDate);
                        result.Total = await accessoryQuery.CountAsync();
                        result.Data = _mapper.Map<List<GoodModel>>(accessoryQuery);
                        break;
                    case 1:
                        IQueryable<SteelProdBE.Entities.Profile> profileQuery = _unitOfWork.dbContext.Profiles;
                        if (!string.IsNullOrEmpty(filterRequest)) profileQuery = profileQuery.Where(x => x.Name.Contains(filterRequest));
                        if (fromDate != null) profileQuery = profileQuery.Where(x => x.LastDeliveryDate >= fromDate);
                        if (toDate != null) profileQuery = profileQuery.Where(x => x.LastDeliveryDate <= toDate);
                        result.Total = await profileQuery.CountAsync();
                        result.Data = _mapper.Map<List<GoodModel>>(profileQuery);
                        break;
                    case 2:
                        IQueryable<Material> materialQuery = _unitOfWork.dbContext.Materials;
                        if (!string.IsNullOrEmpty(filterRequest)) materialQuery = materialQuery.Where(x => x.Name.Contains(filterRequest));
                        if (fromDate != null) materialQuery = materialQuery.Where(x => x.LastDeliveryDate >= fromDate);
                        if (toDate != null) materialQuery = materialQuery.Where(x => x.LastDeliveryDate <= toDate);
                        result.Total = await materialQuery.CountAsync();
                        result.Data = _mapper.Map<List<GoodModel>>(materialQuery);
                        break;
                    default:
                        break;
                }

                _logger.LogInformation(nameof(Get));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Si è verificato un errore");
            }

        }

        private GoodModel MapAccessoryToGoodModal(Accessory? accessory)
        {
            return new GoodModel
            {
                Id = accessory?.Id ?? 0,
                Code = accessory?.Code ?? "",
                Name = accessory?.Name ?? "",
                Description = accessory?.Description ?? string.Empty,
                Quantity = accessory?.Quantity ?? 0,
                SupplierId = accessory?.SupplierId,
                SupplierName = accessory?.Supplier?.Name ?? string.Empty,
                UnitOfMeasure = accessory?.UnitOfMeasure ?? string.Empty
            };
        }

        private GoodModel MapMaterialToGoodModal(Material? material)
        {
            return new GoodModel
            {
                Id = material?.Id ?? 0,
                Name = material?.Name ?? "",
                Code = material?.Code ?? "",
                Description = material?.Description ?? string.Empty,
                Quantity = material?.Quantity ?? 0,
                SupplierId = material?.SupplierId,
                SupplierName = material?.Supplier?.Name ?? string.Empty,
                UnitOfMeasure = material?.UnitOfMeasure ?? string.Empty
            };
        }

        private GoodModel MapProfileToGoodModal(SteelProdBE.Entities.Profile? profile)
        {
            return new GoodModel
            {
                Id = profile?.Id ?? 0,
                Name = profile?.Name ?? "",
                Code = profile?.Code ?? "",
                Description = profile?.Description ?? string.Empty,
                Quantity = profile?.Quantity ?? 0,
                SupplierId = profile?.SupplierId,
                SupplierName = profile?.Supplier?.Name ?? string.Empty,
                UnitOfMeasure = profile?.UnitOfMeasure ?? string.Empty
            };
        }
    }
}
