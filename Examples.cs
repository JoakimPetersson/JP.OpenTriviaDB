using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaDBApiRequester
{
    class Examples
    {
        static public void Main(String[] args)
        {
            OpenTriviaDBApiRequester requester = new OpenTriviaDBApiRequester();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Example code output");
            Console.WriteLine("-------------------------------------");

            // Requesting a single random question
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("A single random question");
            Console.WriteLine("-------------------------------------");

            QuestionsResponse Questions = requester.RequestQuestions(1);

            PrintQuestion(Questions.Questions[0]);

            // Requesting a single random question
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Three sports questions");
            Console.WriteLine("-------------------------------------");

            CategoryListResponse AllCategories = requester.RequestCategoryList();
            CategoryData SportsCategory = AllCategories.CategoryList.Find(x => x.Name == "Sports");

            QuestionsResponse SportsQuestions = requester.RequestQuestions(3, categoryID: SportsCategory.ID);
            PrintQuestion(SportsQuestions.Questions[0]);
            Console.WriteLine("-------------------------------------");
            PrintQuestion(SportsQuestions.Questions[1]);
            Console.WriteLine("-------------------------------------");
            PrintQuestion(SportsQuestions.Questions[2]);

            Console.ReadKey();

        }


        static public void PrintQuestion(QuestionData question)
        {
            Console.WriteLine("Category: " + question.Category);
            Console.WriteLine("Difficulty: " + question.Difficulty);
            Console.WriteLine("Question: " + question.Question);
            Console.WriteLine("Correct Answer: " + question.CorrectAnswer);

            foreach (string incorrectAnswer in question.IncorrectAnswers)
            {
                Console.WriteLine("Incorrect Answer: " + incorrectAnswer);
            }
        }
    }
}
