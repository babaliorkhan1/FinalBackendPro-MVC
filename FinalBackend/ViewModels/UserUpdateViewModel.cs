using System.ComponentModel.DataAnnotations;

namespace FinalBackend.ViewModels
{
    public class UserUpdateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string? CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string? newPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        public string? ConfirmNewPassword { get; set; }
    }
}
