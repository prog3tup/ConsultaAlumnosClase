using ConsultaAlumnosClase.API.DBContext;

namespace ConsultaAlumnosClase.API.Data
{
    public class Repository : IRepository
    {
        internal readonly Context _context;

        public Repository(Context context)
        {
            this._context = context;
        }

        public bool GuardarCambios()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
