using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestsOutputModel
    {
        //модель для вывода всех тестов(только названия)/фидбэков/тэгов

        public List<TestOutputModel> Tests { get; set; }
        public List<TagOutputModel> Tags { get; set; }
        public List<FeedbackOutputModel> Feedbacks { get; set; }
    }
}
