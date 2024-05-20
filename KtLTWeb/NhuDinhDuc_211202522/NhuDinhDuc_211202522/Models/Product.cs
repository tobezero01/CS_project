using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhuDinhDuc_211202522.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public string? Image { get; set; }
        public bool Available { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int ProviderId { get; set; }
        [ValidateNever]
        public virtual Category Category { get; set; } = null!;
        [ValidateNever]
        public virtual Provider Provider { get; set; } = null!;
        [ValidateNever]
        public virtual ICollection<Comment> Comments { get; set; }
        [ValidateNever]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
