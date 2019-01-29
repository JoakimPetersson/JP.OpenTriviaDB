using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace OpenTriviaDBApiRequester
{
    public class OpenTriviaDBApiRequester
    {
        public OpenTriviaDBApiRequester() { }

        /** Public methods **/
        public QuestionsResponse RequestQuestions(uint amount, 
                                                QuestionDifficulty difficulty = QuestionDifficulty.Undefined,
                                                QuestionType type = QuestionType.Undefined,
                                                ResponseEncoding encoding = ResponseEncoding.Undefined,
                                                uint categoryID = 0,
                                                string sessionToken = "")
        {
            string Url = "https://opentdb.com/api.php?amount=" + amount;

            if (categoryID != 0)
            {
                Url += "&category=" + categoryID;
            }

            if (difficulty != QuestionDifficulty.Undefined)
            {
                Url += "&difficulty=" + difficulty.ToString().ToLower();
            }

            if (type != QuestionType.Undefined)
            {
                Url += "&type=" + type.ToString().ToLower();
            }

            if (encoding != ResponseEncoding.Undefined)
            {
                Url += "&encode=" + encoding.ToString();
            }

            if (sessionToken != "")
            {
                Url += "&token=" + sessionToken;
            }

            string JsonString = SendAPIRequest(Url);
            return JsonConvert.DeserializeObject<QuestionsResponse>(JsonString);
        }

        public SessionTokenResponse RequestSessionToken()
        {
            string jsonString = SendAPIRequest("https://opentdb.com/api_token.php?command=request");
            return JsonConvert.DeserializeObject<SessionTokenResponse>(jsonString);
        }

        public CategoryListResponse RequestCategoryList()
        {
            string jsonString = SendAPIRequest("https://opentdb.com/api_category.php");
            jsonString = jsonString.Substring(jsonString.IndexOf(":") + 1);
            jsonString = jsonString.Remove(jsonString.Length - 1);
            CategoryListResponse Output = new CategoryListResponse();
            Output.CategoryList = new List<CategoryData>();
            Output.CategoryList  = (JsonConvert.DeserializeObject<List<CategoryData>>(jsonString));
            return Output;
        }

        public NumberOfQuestionsInCategoryResponse RequestNumberOfQuestionsInCategory(uint category_id)
        {
            string jsonString = SendAPIRequest("https://opentdb.com/api_count.php?category=" + category_id);
            return JsonConvert.DeserializeObject<NumberOfQuestionsInCategoryResponse>(jsonString);
        }

        // Method for checking the total number of questions
        public GlobalQuestionCountResponse RequestGlobalQuestionCount()
        {
            string jsonString = SendAPIRequest("https://opentdb.com/api_count_global.php");
            Console.WriteLine(jsonString);
            return JsonConvert.DeserializeObject<GlobalQuestionCountResponse>(jsonString);
        }

        /** Private Methods **/
        private string SendAPIRequest(string url)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(String.Format(url));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }
    }
}
