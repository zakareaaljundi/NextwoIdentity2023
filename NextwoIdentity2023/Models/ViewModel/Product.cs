using System.ComponentModel.DataAnnotations.Schema;

namespace NextwoIdentity2023.Models.ViewModel
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
