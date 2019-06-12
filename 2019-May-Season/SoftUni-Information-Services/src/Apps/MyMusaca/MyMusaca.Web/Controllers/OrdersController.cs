using MyMusaca.Services;
using MyMusaca.Web.BindingModels;
using MyMusaca.Web.BindingModels.Orders;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MyMusaca.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize, HttpPost]
        public IActionResult AddProduct(OrderAddProductBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.ordersService.AddProductToActiveOrder(model.Product, this.User.Id);
            }

            return this.Redirect("/Home/IndexUser");
        }

        [Authorize]
        public IActionResult Complete(OrdersCompleteBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.ordersService.CompleteOrder(
                    this.ordersService.GetActiveOrder(
                        this.User.Id));
            }

            return this.Redirect("/Home/IndexUser");
        }
    }
}