namespace EasyBarcodeMAU.Models.Aggregate;
public interface IOutputRepositories
    : IRepository<OutPutProductModel> {
    Task<bool> ExistsAsync(string outputProductModel);
    Task AddAsync(OutPutProductModel outPutProductModel);
    void RemoveAsync(OutPutProductModel outPutProductModel);
}