using ConsultaAlumnosClase.API.Entities;
using static ConsultaAlumnos.API.Controllers.AutenticacionController;

namespace ConsultaAlumnosClase.API.Data
{
    public interface IUsuarioRepository
    {
        public Usuario? ValidarUsuario(AuthenticationRequestBody requestBody);
    }
}
