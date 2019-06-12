using MyMusaca.Services;
using MyMusaca.Web.BindingModels;
using MyMusaca.Web.ViewModels;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace MyMusaca.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public IActionResult All()
        {
            var allProducts = this.productsService.GetAllProducts();
            var viewModel = new ProductsAllViewModel
            {
                Products = allProducts.To<ProductAllViewModel>()
            };
            
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize, HttpPost]
        public IActionResult Create(ProductCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            if (this.productsService.CreateProduct(model.Name, model.Price))
            {
                return this.Redirect("/Products/All");
            }

            return this.Redirect("/Products/Create");
        }
    }
}