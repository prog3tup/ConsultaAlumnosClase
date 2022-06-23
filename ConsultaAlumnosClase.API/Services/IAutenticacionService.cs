using ConsultaAlumnosClase.API.Entities;
using static ConsultaAlumnos.API.Controllers.AutenticacionController;

namespace ConsultaAlumnosClase.API.Services
{
    public interface IAutenticacionService
    {
        public Usuario? AutenticarUsuario(AuthenticationRequestBody authenticationRequest);
    }
}
