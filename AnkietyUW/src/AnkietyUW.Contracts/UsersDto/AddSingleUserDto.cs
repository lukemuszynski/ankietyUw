using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.UsersDto
{
    public class AddSingleUserDto
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public Guid TestId { get; set; }
    }
}
