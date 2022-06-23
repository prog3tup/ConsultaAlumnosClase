using ConsultaAlumnosClase.API.DBContext;
using ConsultaAlumnosClase.API.Entities;
using static ConsultaAlumnos.API.Controllers.AutenticacionController;

namespace ConsultaAlumnosClase.API.Data
{
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }

        public Usuario? ValidarUsuario(AuthenticationRequestBody requestBody)
        {
            if(requestBody.TipoUsuario == "alumno")
                return _context.Alumnos.FirstOrDefault(a => a.NombreUsuario == requestBody.UserName && a.Password == requestBody.Password);
            return _context.Profesores.FirstOrDefault(p => p.NombreUsuario == requestBody.UserName && p.NombreUsuario == requestBody.Password); 
        }
    }
}
