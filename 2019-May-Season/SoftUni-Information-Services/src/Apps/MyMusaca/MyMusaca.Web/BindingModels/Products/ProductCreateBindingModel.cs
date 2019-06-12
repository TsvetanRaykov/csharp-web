using SIS.MvcFramework.Attributes.Validation;

namespace MyMusaca.Web.BindingModels.Products
{
    public class ProductCreateBindingModel
    {
        private const string PriceErrorMessage = "Price is Invalid, must be higher than 0.01!";
        private const string NameErrorMessage = "Name is Invalid, must be between 3 and 10 symbols!";

        [RequiredSis]
        [StringLengthSis(3, 10, NameErrorMessage)]
        public string Name { get; set; }
        [RequiredSis]
        [RangeSis(typeof(decimal), "0.01", "79228162514264337593543950335", PriceErrorMessage)]
        public decimal Price { get; set; }
    }
}