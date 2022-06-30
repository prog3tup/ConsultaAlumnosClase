namespace ConsultaAlumnosClase.API.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuatrimestre { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Profesor> Profesores { get; set; }
    }
}
