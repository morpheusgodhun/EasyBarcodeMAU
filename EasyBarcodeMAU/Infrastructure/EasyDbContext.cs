using EasyBarcodeMAU.Models;
using Microsoft.EntityFrameworkCore;

public class EasyDbContext : DbContext {
    public EasyDbContext(DbContextOptions<DbContext> options)
        : base(options) {
    }
    public DbSet<OutPutProductModel> outPutProductModels { get; set; }
    public DbSet<ProductModel> productModels { get; set; }
    public DbSet<OutputProductItems> outputProductItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Server=(local);Database=DboUrunGirisCikis;Integrated Security=True;");
        }
    }
}