namespace QuizApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public string Explanation { get; set; }
    }
}
