namespace FinalBackend.Models
{
    public class Car:BaseModel
    {
        public string Name { get; set; }    
        public string Year { get; set; }        
        public string Price { get; set; }   
        public string Info1 { get; set; }   
        public string Info2 { get; set; }   
        public string Info3 { get; set; }   
    }
}
