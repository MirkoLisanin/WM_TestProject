namespace WM_TestProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }

        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        [Required]
        [StringLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(30)]
        public string Supplier { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
