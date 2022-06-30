using ConsultaAlumnosClase.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnosClase.API.Services
{
    public interface IStudentService
    {
        public ActionResult<ICollection<SubjectDto>> GetSubjectsbyStudent(int studentId);
    }
}
