namespace ConsultaAlumnosClase.API.Models
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompletedName { get => Name + " " + LastName; }
    }
}
