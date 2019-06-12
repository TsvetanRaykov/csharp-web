using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMusaca.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
            this.Status = OrderStatus.Active;
        }

        [Key]
        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime? IssuedOn { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [Required]
        public string CashierId { get; set; }

        public virtual User Cashier { get; set; }
    }
}