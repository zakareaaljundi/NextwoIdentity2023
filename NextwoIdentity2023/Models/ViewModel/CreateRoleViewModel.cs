using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity2023.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
