using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;

namespace AnkietyUW.Contracts.TestDto.ViewModels
{
    public class TestWithTestTimesViewModel
    {
        public Guid Id { get; set; }
        public int FirstQuestionAddSeconds { get; set; }
        public int SecondQuestionAddSeconds { get; set; }
        public int ThirdQuestionAddSeconds { get; set; }
        public int FourthQuestionAddSeconds { get; set; }
        public int CompletedSeriesCounter { get; set; }
        public int TimeToFillTestAddSeconds { get; set; }
        public ICollection<TestTimeDto> TestTimes { get; set; }
    }
}
