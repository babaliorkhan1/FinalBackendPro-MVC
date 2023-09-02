using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBackend.ViewModels
{
    public class RegsiterViewModel
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
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsTerms { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; } 
    }
}
