using MyMusaca.Services;
using MyMusaca.Web.ViewModels;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace MyMusaca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService ordersService;

        public HomeController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }
        public IActionResult Index()
        {
            if (!this.IsLoggedIn())
            {
                return this.View();
            }

            return this.IndexUser();
        }

        [Authorize]
        public IActionResult IndexUser()
        {
            var viewModel = new IndexUserProductsViewModel
            {
                Products = this.ordersService.GetActiveOrder(this.User.Id).Products.To<IndexUserProductViewModel>()
            };
            return this.View(viewModel);
        }
    }
}
