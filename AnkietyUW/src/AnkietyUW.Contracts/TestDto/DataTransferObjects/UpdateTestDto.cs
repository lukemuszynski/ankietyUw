using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnkietyUW.Contracts.TestDto.DataTransferObjects
{
    public class UpdateTestDto
    {
        [Required]
        [StringLength(36, MinimumLength = 36)]
        public string Id { get; set;  }
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
