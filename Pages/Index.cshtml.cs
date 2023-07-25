using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PurchaseOrderExtraction.Models;
using PurchaseOrderExtraction.Services;

namespace powebapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> _products;        
        public readonly IProductService _productService;


        public IndexModel(IProductService productService)
        {
            //_logger = logger;
            _products = new List<Product>();
            _productService = productService;
        }

        public void OnGet()
        {
            ProductService productService = new ProductService();
            _products = productService.GetProducts();

            //_products = _productService.GetProducts();
        }
    }
}