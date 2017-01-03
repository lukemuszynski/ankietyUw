using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnkietyUW.DataLayer.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        private List<int?> Answers { get; set; }

        public string AnswersCSV
        {
            get
            {
                StringBuilder str = new StringBuilder();

                for (int i = 0; i < Answers.Count; i++)
                {
                    if (Answers[i] != null)
                        str.Append(Answers[i]);
                    if (i + 1 < Answers.Count)
                        str.Append(";");
                }

                return str.ToString();

            }

            set
            { 
                var splitted = value.Split(';');
                foreach (var s in splitted)
                {
                    if (s != "")
                        Answers.Add(Int32.Parse(s));
                    else
                    {
                        Answers.Add(null);
                    }
                }
            }

        }


    }
}
