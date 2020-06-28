using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Shared
{
    public enum Role
    {
        Admin=1,
        Student,
        Author,
        Teacher,
        Test
    }

    public enum QuestionType
    {
        SingleAnswer = 1,
        MultipleAnswers,
        TextAnswer,
        CodeString
    }
}

