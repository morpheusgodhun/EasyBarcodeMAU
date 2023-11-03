using EasyBarcodeMAU.Models;
using EasyBarcodeMAU.Models.Aggregate;

namespace EasyBarcodeMAU.Infrastructure.Repositories {
    public class OutputRepositories : IOutputRepositories {
        public OutputRepositories(DbContext context) {
            contx = context ?? throw new ArgumentNullException(nameof(context));
        }
        private readonly DbContext contx;
        public async Task AddAsync(OutPutProductModel outPutProductModel) {
            await contx.AddAsync(outPutProductModel);
        }

        public void RemoveAsync(OutPutProductModel outPutProductModel) {
            contx.Remove(outPutProductModel);
        }

        public Task<bool> ExistsAsync(string OutputProductModel) {
            return Task.FromResult(false);
        }
    }
}
