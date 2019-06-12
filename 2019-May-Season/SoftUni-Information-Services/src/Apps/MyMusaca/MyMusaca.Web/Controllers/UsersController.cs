using System.Linq;
using MyMusaca.Services;
using MyMusaca.Web.BindingModels;
using MyMusaca.Web.BindingModels.Users;
using MyMusaca.Web.ViewModels;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MyMusaca.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOrdersService ordersService;

        public UsersController(IUsersService usersService, IOrdersService ordersService)
        {
            this.usersService = usersService;
            this.ordersService = ordersService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.usersService.CreateUser(model.Username, model.Email, model.Password);
            if (string.IsNullOrEmpty(userId))
            {
                return this.Redirect("/Users/Register");
            }

            this.SignIn(userId, model.Username, model.Email);

            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.usersService.GetUserOrNull(model.Username, model.Password);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");

        }

        [Authorize]
        public IActionResult Profile()
        {
            var userOrders = this.ordersService.GetAllCompletedUserOrders(this.User.Id);
            var viewModel = new UserProfileViewModel
            {
                Orders = userOrders.Select(o => new UserProfileOrderViewModel
                {
                    Id = o.Id,
                    Cashier = o.Cashier.Username,
                    IssuedOn = $"{o.IssuedOn:d}",
                    Total = $"{o.Products.Sum(p => p.Price):N2}"
                })
            };
            return this.View(viewModel);
        }
    }
}
