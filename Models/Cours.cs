namespace AuthMvc.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public Enseignant? Enseignant { get; set; }


    }
}
