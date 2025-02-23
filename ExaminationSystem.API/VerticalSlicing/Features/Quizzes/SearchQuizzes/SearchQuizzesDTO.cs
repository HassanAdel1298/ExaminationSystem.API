﻿namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes
{
    public class SearchQuizzesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateOfQuiz { get; set; }
    }
}
