using ConsultaAlumnosClase.API.DBContext;
using ConsultaAlumnosClase.API.Entities;

namespace ConsultaAlumnosClase.API.Data
{
    public class QuestionRepository:Repository, IQuestionRepository
    {
        public QuestionRepository(Context context) : base(context)
        {
        }

        public void AddQuestion(Question question)
        {
            _context.Add(question);
        }
    }
}
