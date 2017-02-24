using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.UsersDto
{
    public class AddMultipleUsersDto
    {
        [Required]
        [StringLength(36, MinimumLength = 36)]
        public string TestId { get; set; }
        [Required]
        public ICollection<string> Keys { get; set; }
    }
}
