using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.TestDto.DataTransferObjects
{
    public class CreateTestDto
    {
        [Required]
        public int FirstQuestionAddSeconds { get; set; }
        [Required]
        public int SecondQuestionAddSeconds { get; set; }
        [Required]
        public int ThirdQuestionAddSeconds { get; set; }
        [Required]
        public int FourthQuestionAddSeconds { get; set; }
        [Required]
        public int CompletedSeriesCounter { get; set; }
        [Required]
        public ICollection<TestTimeDto> TestTimes { get; set; }
        [Required]
        public int TimeToFillTestAddSeconds { get; set; }
    }
}
