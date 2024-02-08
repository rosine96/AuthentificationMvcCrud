namespace AuthMvc.Models
{
    public class Enseignant
    {
        public int Id { get; set; }
        public string?  Name { get; set; }
         public ICollection<Cours>?Cours { get; set; }


    }
}
