using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.TestDto.DataTransferObjects
{
    public class TestTimeDto
    {
        [Required]
        public DateTime DateTime { get; set; }
    }
}
