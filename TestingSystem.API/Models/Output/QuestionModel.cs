﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public int Weight { get; set; }
        public List<string> Answers { get; set; }
    }
}
