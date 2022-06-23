using ConsultaAlumnosClase.API.Data;
using ConsultaAlumnosClase.API.Entities;
using static ConsultaAlumnos.API.Controllers.AutenticacionController;

namespace ConsultaAlumnosClase.API.Services
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacionService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario? AutenticarUsuario(AuthenticationRequestBody authenticationRequest)
        {
            if(String.IsNullOrEmpty(authenticationRequest.UserName) || String.IsNullOrEmpty(authenticationRequest.Password))
            {
                return null;
            }
            return _usuarioRepository.ValidarUsuario(authenticationRequest);
        }
    }
}
