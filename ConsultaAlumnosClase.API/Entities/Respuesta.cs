namespace ConsultaAlumnosClase.API.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaCreacion { get; set; }
        //[ForeignKey("IdCreador")]
        public Usuario Creador { get; set; }
        //public int IdCreador { get; set; }
        //[ForeignKey("IdConsulta")]
        public Consulta Consulta { get; set; }
        //public int IdConsulta { get; set; }
    }
}
