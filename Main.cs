using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaDBApiRequester
{
    class Test
    {
        static public void Main(String[] args)
        {
            OpenTriviaDBApiRequester db = new OpenTriviaDBApiRequester();

            GlobalQuestionCountResponse response = db.RequestGlobalQuestionCount();

            Console.WriteLine(response.Overall.TotalNumberOfQuestions);
            Console.ReadKey();

           // Console.WriteLine("Main Method");
        }
    }
}
