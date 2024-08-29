using Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string? Name { get; private set; }
        [Required(ErrorMessage = "The description is required")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string? Description { get; private set; }
        [Required(ErrorMessage = "The price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        public decimal Price { get; private set; }
        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }
        [MaxLength(250)]
        [DisplayName("Product image")]  
        public string? Image { get; private set; }
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
