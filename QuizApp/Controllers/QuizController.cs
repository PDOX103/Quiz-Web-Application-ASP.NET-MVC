using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "3 cats catch 3 mice in 3 minutes. How many cats to catch 100 mice in 100 minutes?",
                    Options = new List<string> { "1", "2", "3", "9" },
                    CorrectOptionIndex = 2,
                    Explanation = "Rate: 3 cats → 3 mice in 3 min ⇒ each cat catches 1 mouse per 3 min. " +
                                  "In 100 min, one cat catches 100/3 ≈ 33⅓ mice, so 3 cats catch 100 mice."
                },

                new Question
                {
                    Id = 2,
                    Text = "A bat and a ball cost $1.10. The bat costs $1 more than the ball. How much is the ball?",
                    Options = new List<string> { "$0.05", "$0.10", "$0.01", "$0.15" },
                    CorrectOptionIndex = 0,
                    Explanation = "Let the ball be x. Then bat = x + 1. So x + (x + 1) = 1.10 ⇒ 2x = 0.10 ⇒ x = $0.05."
                },

                new Question
                {
                    Id = 3,
                    Text = "There are 100 doors toggled on passes 1–100. How many doors are open at the end?",
                    Options = new List<string> { "9", "10", "11", "50" },
                    CorrectOptionIndex = 1,
                    Explanation = "A door ends up open if it’s toggled an odd number of times → only perfect squares " +
                                  "have an odd number of divisors. Squares ≤ 100: 1,4,9,...,100 → 10 doors."
                },

                new Question
                {
                    Id = 4,
                    Text = "Two fathers and two sons catch three fish, one each. How is it possible?",
                    Options = new List<string>
                    {
                        "They miscounted",
                        "They are triplets",
                        "They are grandfather, father, and son",
                        "One is imaginary"
                    },
                    CorrectOptionIndex = 2,
                    Explanation = "Three people: a grandfather, his son, and his grandson. That’s two fathers and two " +
                                  "sons total; three fish fits perfectly."
                },

                new Question
                {
                    Id = 5,
                    Text = "Which weighs more?",
                    Options = new List<string> { "1 kg of iron", "1 kg of cotton", "Both weigh the same", "Depends on volume" },
                    CorrectOptionIndex = 2,
                    Explanation = "One kilogram is one kilogram regardless of the material; only volume/bulk differs, not weight."
                },

                new Question
                {
                    Id = 6,
                    Text = "Find the next number: 2, 3, 5, 9, 17, ?",
                    Options = new List<string> { "26", "31", "33", "35" },
                    CorrectOptionIndex = 2,
                    Explanation = "Pattern: each term is (previous × 2) − 1. 17 × 2 − 1 = 33."
                }
            };
        }

        public IActionResult Index()
        {
            var model = new QuizSubmission
            {
                Questions = GetQuestions()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(QuizSubmission submission)
        {
            var questions = GetQuestions();
            int score = 0;

            foreach (var q in questions)
            {
                if (submission.UserAnswers.ContainsKey(q.Id) &&
                    submission.UserAnswers[q.Id] == q.CorrectOptionIndex)
                {
                    score++;
                }
            }

            submission.Questions = questions;
            submission.Score = score;

            return View("Result", submission);
        }
    }
}
