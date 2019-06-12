namespace MyMusaca.Web.ViewModels
{
    public class IndexUserProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice => $"{this.Price:N2}";
    }
}