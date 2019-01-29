# OpenTriviaDBApiRequester

Simple tool for making API requests to OpenTrivia DB in C#. It makes the request to the API for you and converts the Json to a object.

Check out https://opentdb.com/ for more information about the database and in-depth details about the API.

## How to use

All request methods start with the word "Request", and they all return a class ending with "Response". 

For example:
```
OpenTriviaDBApiRequester requester = new OpenTriviaDBApiRequester();
QuestionsResponse OneQuestion = requester.RequestQuestions(1);
```

### RequestQuestions()

#### Description
The method used for requesting questions from the API. It returns a QuestionsResponse object.

#### Parameters
uint amount: The amount of questions you want to request
QuestionDifficulty difficulty (enum, optional): The difficulty of the questions requested. Easy, Medium, or Hard. If left empty the questions recieved will have mixed difficulty levels.
QuestionType type (enum, optional): The type of questions requested. Multiple or Boolean. If left empty the questions will have mixed types.
ResponseEncoding encoding (enum, optional): The type of encoding used in the response. urlLegacy, url3986, or base64. If left empty it will use the default encoding (UTF8).
uint categoryID (optional): The category of the questions requested. Use a category ID from the category list. If left empty the questions will have mixed categories.
string sessionToken (optional): Using a session token will prevent the API from giving you the same question twice until you reset the token.


