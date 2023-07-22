using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PurchaseOrderExtraction.Models;
using PurchaseOrderExtraction.Services;

namespace powebapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> Products;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Products = new List<Product>();
        }

        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}