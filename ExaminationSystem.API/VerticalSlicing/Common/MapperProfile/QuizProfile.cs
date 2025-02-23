using AutoMapper;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes;
using ExaminationSystem.VerticalSlicing.Features.Quizzes.CreateQuiz.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Common.MapperProfile
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {

            CreateMap<Quiz, SearchQuizzesDTO>().ReverseMap();
            CreateMap<Quiz, CreateQuizCommand>().ReverseMap();

        }
    }
}
