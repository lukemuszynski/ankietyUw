using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.DataLayer.Entities
{
    public class Secret
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int SeriesNumber { get; set; }
    }
}
