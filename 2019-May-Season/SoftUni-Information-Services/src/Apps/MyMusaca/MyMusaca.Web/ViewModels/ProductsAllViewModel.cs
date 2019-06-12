using System.Collections.Generic;

namespace MyMusaca.Web.ViewModels
{
    public class ProductsAllViewModel
    {
        public ProductsAllViewModel()
        {
            this.Products = new HashSet<ProductAllViewModel>();
        }
        public IEnumerable<ProductAllViewModel> Products { get; set; }
    }
}