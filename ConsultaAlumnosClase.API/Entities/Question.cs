using ConsultaAlumnosClase.API.Enums;

namespace ConsultaAlumnosClase.API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        //[ForeignKey("IdProfesor")]
        public Profesor ProfesorAsignado { get; set; }
        //public int IdProfesor { get; set; }
        //[ForeignKey("IdAlumnoCreador")]
        public Alumno Alumno { get; set; }
        //public int IdAlumnoCreador { get; set; }
        //[ForeignKey("IdMateria")]
        public Subject Materia { get; set; }
        //public int IdMateria { get; set; }
        //public ICollection<Alumno> Seguidores { get; set; } = new List<Alumno>();
        public ICollection<Respuesta> Respuestas { get; set; } = new List<Respuesta>();
        public EstadosConsulta EstadoConsulta { get; set; } = EstadosConsulta.EsperandoRespuestaDelProfesor;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
    }
}
