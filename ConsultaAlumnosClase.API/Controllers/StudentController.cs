using ConsultaAlumnosClase.API.Models;
using ConsultaAlumnosClase.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaAlumnosClase.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService autenticacionService)
        {
            this._studentService = autenticacionService;
        }

        [HttpGet("subjects")]
        public ActionResult<ICollection<SubjectDto>> GetSubjects()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "alumno")
                return Forbid();
            return _studentService.GetSubjectsbyStudent(int.Parse(userId));            
        }



    }
}
