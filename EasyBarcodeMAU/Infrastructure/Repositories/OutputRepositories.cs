using EasyBarcodeMAU.Models;
using EasyBarcodeMAU.Models.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace EasyBarcodeMAU.Infrastructure.Repositories {
    public class OutputRepositories : IOutputRepositories {
        public OutputRepositories(EasyDbContext context) {
            cntx = context ?? throw new ArgumentNullException(nameof(context));
        }
        private readonly EasyDbContext cntx;
        public async Task AddAsync(OutputProductItems outputProductItems) {
            await cntx.AddAsync(outputProductItems);
        }

        public void RemoveAsync(OutputProductItems outputProductItems) {
            cntx.Remove(outputProductItems);
        }

        public Task<bool> ExistsAsync(string OutputProductModel) {
            return Task.FromResult(false);
        }

        public async Task<List<OutputProductItems>> GetAllAsync() {
            return await cntx.outputProductItems.ToListAsync();
        }

        
    }
}
