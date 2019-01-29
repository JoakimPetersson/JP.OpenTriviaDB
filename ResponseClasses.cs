using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaDBApiRequester
{
    // Data classes
    // These contain information about a certain part of a request response
    public class QuestionData
    {
        [JsonProperty("category")]
        public string Category;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("difficulty")]
        public string Difficulty;

        [JsonProperty("question")]
        public string Question;

        [JsonProperty("correct_answer")]
        public string CorrectAnswer;

        [JsonProperty("incorrect_answers")]
        public string[] IncorrectAnswers;
    }

    public class CategoryData
    {
        [JsonProperty("id")]
        public uint ID;

        [JsonProperty("name")]
        public string Name;
    }

    public class CategoryQuestionCount
    {
        [JsonProperty("total_question_count")]
        public uint TotalQuestionCount;

        [JsonProperty("easy_question_count")]
        public uint EasyQuestionCount;

        [JsonProperty("medium_question_count")]
        public uint MediumQuestionCount;

        [JsonProperty("hard_question_count")]
        public uint HardQuestionCount;
    }

    public class CategoryQuestionData
    {
        [JsonProperty("total_num_of_questions")]
        public uint TotalNumberOfQuestions;

        [JsonProperty("total_num_of_pending_questions")]
        public uint TotalNumberOfPendingQuestions;

        [JsonProperty("total_num_of_verified_questions")]
        public uint TotalNumberOfVerifiedQuestions;

        [JsonProperty("total_num_of_rejected_questions")]
        public uint TotalNumberOfRejectedQuestions;
    }

    /** Response Classes **/
    // When you send a request to the API you will get an instance of one of these classes as a response

    public class QuestionsResponse
    {
        [JsonProperty("response_code")]
        public uint ResponseCode;

        [JsonProperty("results")]
        public List<QuestionData> Questions;
    }

    public class SessionTokenResponse
    {
        [JsonProperty("response_code")]
        public string ResponseCode;

        [JsonProperty("response_message")]
        public string ResponseMessage;

        [JsonProperty("token")]
        public string Token;
    }

    public class CategoryListResponse
    {
        [JsonProperty("trivia_categories")]
        public List<CategoryData> CategoryList;
    }

    public class NumberOfQuestionsInCategoryResponse
    {
        [JsonProperty("category_id")]
        public uint CategoryId;

        [JsonProperty("category_question_count")]
        public CategoryQuestionCount CategoryQuestionCount;
    }

    public class GlobalQuestionCountResponse
    {
        [JsonProperty("overall")]
        public CategoryQuestionData Overall;

        [JsonProperty("categories")]
        public Dictionary<uint, CategoryQuestionData> CategoriesQuestionCount;
    }
}
