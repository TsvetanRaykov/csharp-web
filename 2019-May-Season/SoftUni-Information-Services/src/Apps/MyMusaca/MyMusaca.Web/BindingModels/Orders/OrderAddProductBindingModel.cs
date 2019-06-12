using SIS.MvcFramework.Attributes.Validation;

namespace MyMusaca.Web.BindingModels.Orders
{
    public class OrderAddProductBindingModel
    {
        [RequiredSis]
        public string Product { get; set; }
    }
}