using EasyBarcodeMAU.Models;
using Microsoft.EntityFrameworkCore;

public class Infrastructure : DbContext {
    public Infrastructure(DbContextOptions<Infrastructure> options)
        : base(options) {
    }
    public DbSet<OutPutProductModel> outPutProductModels { get; set; }
    public DbSet<ProductModel> productModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Server=(local);Database=DboUrunGirisCikis;Integrated Security=True;");
        }
    }
}