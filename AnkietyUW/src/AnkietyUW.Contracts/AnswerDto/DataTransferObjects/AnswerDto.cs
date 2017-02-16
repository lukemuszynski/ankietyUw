using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.AnswerDto.DataTransferObjects
{
    public class AnswerDto
    {
        public List<int?> Answers { get; set; }
    }
}
