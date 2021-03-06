﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.TestDto.ViewModels
{
    public class TestViewModel
    {
        public Guid Id { get; set; }
        public int FirstQuestionAddSeconds { get; set; }
        public int SecondQuestionAddSeconds { get; set; }
        public int ThirdQuestionAddSeconds { get; set; }
        public int FourthQuestionAddSeconds { get; set; }
        public int CompletedSeriesCounter { get; set; }
        public int TimeToFillTestAddSeconds { get; set; }
    }
}
