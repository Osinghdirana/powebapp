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
        public IProductService _productService;


        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            //Products = new List<Product>();
            _productService = productService;
        }

        public void OnGet()
        {
            //ProductService productService = new ProductService();
            //Products = productService.GetProducts();

            Products = _productService.GetProducts();
        }
    }
}