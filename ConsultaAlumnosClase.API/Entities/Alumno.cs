namespace ConsultaAlumnosClase.API.Entities
{
    public class Alumno : Usuario
    {
        public ICollection<Subject> MateriasEnCurso { get; set; } = new List<Subject>();
        public ICollection<Question> Consultas { get; set; } = new List<Question>();
    }
}
