﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.EmailDto.DataTransferObjects
{
    public class SendEmailDto
    {
        [Required]
        public Guid UserGuid { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string HtmlContent { get; set; }
    }
}
