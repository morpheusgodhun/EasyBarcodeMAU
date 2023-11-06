namespace EasyBarcodeMAU.Models.Aggregate;
public interface IOutputRepositories
    : IRepository<OutPutProductModel> {
    Task<bool> ExistsAsync(string outputProductItems);
    Task AddAsync(OutputProductItems outputProductItems);
    Task<List<OutputProductItems>> GetAllAsync();
    void RemoveAsync(OutputProductItems outputProductItems);
}