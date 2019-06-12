using System.Collections.Generic;
using System.Linq;

namespace MyMusaca.Web.ViewModels
{
    public class IndexUserProductsViewModel
    {
        public IndexUserProductsViewModel()
        {
            this.Products = new HashSet<IndexUserProductViewModel>();
        }

        public string Id { get; set; }

        public IEnumerable<IndexUserProductViewModel> Products { get; set; }

        public string TotalPrice => $"{ this.Products.Sum(p => p.Price):N2}";

    }
}