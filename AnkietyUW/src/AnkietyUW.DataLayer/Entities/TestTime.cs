using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.DataLayer.Entities
{
    public class TestTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}
