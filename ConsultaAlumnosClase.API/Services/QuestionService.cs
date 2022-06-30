using ConsultaAlumnosClase.API.Data;
using ConsultaAlumnosClase.API.Entities;

namespace ConsultaAlumnosClase.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void AddQuestion(Question question)
        {
            _questionRepository.AddQuestion(question);
        }
    }
}
