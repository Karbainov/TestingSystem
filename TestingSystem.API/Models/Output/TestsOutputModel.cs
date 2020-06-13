using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestsOutputModel
    {
        //модель для вывода всех тестов(только названия)/фидбэков/тэгов

        public List<TestOutputModel> tests { get; set; }
        public List<TagOutputModel> tags { get; set; }
        public List<FeedbackOutputModel> feedbacks { get; set; }
    }
}
