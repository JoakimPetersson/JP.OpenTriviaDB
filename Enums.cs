using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaDBApiRequester
{
    public enum QuestionDifficulty
    {
        Undefined, Easy, Medium, Hard
    }

    public enum QuestionType
    {
        Undefined, Multiple, Boolean
    }

    public enum ResponseEncoding
    {
        Undefined, urlLegacy, url3986, base64
    }
}
