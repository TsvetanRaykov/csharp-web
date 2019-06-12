using MyMusaca.Data;
using MyMusaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace MyMusaca.Web
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new MyMusacaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<IProductsService, ProductsService>();
            serviceProvider.Add<IOrdersService, OrdersService>();
        }
    }
}