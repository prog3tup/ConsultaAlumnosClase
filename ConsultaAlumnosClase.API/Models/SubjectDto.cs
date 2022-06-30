namespace ConsultaAlumnosClase.API.Models
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProfesorDto> Professors{ get; set; }
    }
}
