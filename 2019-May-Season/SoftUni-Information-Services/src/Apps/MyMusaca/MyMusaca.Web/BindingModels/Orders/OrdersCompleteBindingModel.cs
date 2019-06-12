using SIS.MvcFramework.Attributes.Validation;

namespace MyMusaca.Web.BindingModels.Orders
{
    public class OrdersCompleteBindingModel
    {
        [RequiredSis]
        public string Id { get; set; }
    }
}