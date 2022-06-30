using ConsultaAlumnosClase.API.DBContext;
using ConsultaAlumnosClase.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnosClase.API.Data
{
    public class StudentRepository : Repository,IStudentRepository
    {
        public StudentRepository(Context context) : base(context)
        {
        }

        public ICollection<Subject> GetStudentSubjects(int studentId)
        {
           return _context.Alumnos.Include(s => s.MateriasEnCurso).ThenInclude(m => m.Profesores).Where(a => a.Id == studentId)
                .Select(a => a.MateriasEnCurso).FirstOrDefault() ?? new List<Subject>();
        }
    }
}
