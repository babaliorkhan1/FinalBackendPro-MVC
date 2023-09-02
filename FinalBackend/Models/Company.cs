using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBackend.Models
{
    public class Company:BaseModel
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string? Image1 { get; set; }   
        public string? Image2 { get; set; }
        [NotMapped]
        public IFormFile FormFile1 { get; set; }
        [NotMapped]
        public IFormFile FormFile2 { get; set; } 

    }
}
