using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.ExtractTestDto.DataTransferObjects
{
    public class ExtractTestDto
    {
        [Required]
        public Guid TestId { get; set; }
    }
}
