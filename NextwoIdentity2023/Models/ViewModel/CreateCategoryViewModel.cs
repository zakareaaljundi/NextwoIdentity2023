using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity2023.Models.ViewModel
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string? CategoryName { get; set; }
    }
}
