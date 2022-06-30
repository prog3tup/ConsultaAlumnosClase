using ConsultaAlumnosClase.API.Data;
using ConsultaAlumnosClase.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnosClase.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult<ICollection<SubjectDto>> GetSubjectsbyStudent(int studentId)
        {
            return _studentRepository.GetStudentSubjects(studentId);
        }
    }
}
