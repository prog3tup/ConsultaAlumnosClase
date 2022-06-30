using ConsultaAlumnosClase.API.Entities;

namespace ConsultaAlumnosClase.API.Data
{
    public interface IQuestionRepository
    {
        public void AddQuestion(Question question);
    }
}
