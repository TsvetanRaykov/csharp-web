namespace MyMusaca.Web.ViewModels
{
    public class ProductAllViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice => $"{this.Price:N2}";
    }
}