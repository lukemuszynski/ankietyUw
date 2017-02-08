using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnkietyUW.DataLayer.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Key { get; set; }
        public string EmailAddress { get; set; }
        public bool Active { get; set; }

        public Sex Sex { get; set; }

        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }

  
}
