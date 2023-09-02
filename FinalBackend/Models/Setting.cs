using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBackend.Models
{
    public class Setting:BaseModel
    {
        [Required]
      public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string? Image1 { get; set; }
        [Required]
        public string AboutTitle { get; set; }
        [Required]
        public string AboutText { get; set; }
        [Required]
        public string? AboutImage { get; set; }
        [Required]
        public string AllTitle { get; set; }
        [Required]  
        public string AboutText1 { get; set; }
        [Required]  
        public string AboutText2 { get; set; }
        [Required]
        public string FooterTitle { get; set; }
        [Required]
        public string FooterText { get; set; }  

        [NotMapped]
        public IFormFile FormFile1 { get; set; }
        [NotMapped]
        public IFormFile FormFile2 { get; set; } 
    }
}
