using PurchaseOrderExtraction.Models;

namespace PurchaseOrderExtraction.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBeta();
    }
}