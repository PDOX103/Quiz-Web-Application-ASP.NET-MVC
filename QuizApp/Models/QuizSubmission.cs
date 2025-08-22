﻿namespace QuizApp.Models
{
    public class QuizSubmission
    {
        public List<Question> Questions { get; set; }
        public Dictionary<int, int> UserAnswers { get; set; } = new Dictionary<int, int>();
        public int Score { get; set; }
    }
}
