using ConsultaAlumnosClase.API.Entities;
using ConsultaAlumnosClase.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnosClase.API.Data
{
    public interface IStudentRepository
    {
        public ICollection<Subject> GetStudentSubjects(int studentId);
    }
}
