namespace ConsultaAlumnosClase.API.Entities
{
    public class Profesor : Usuario
    {
        public ICollection<Subject> MateriasAsignadas { get; set; } = new List<Subject>();
        public ICollection<Question> ConsultasAsignadas { get; set; } = new List<Question>();
    }
}
