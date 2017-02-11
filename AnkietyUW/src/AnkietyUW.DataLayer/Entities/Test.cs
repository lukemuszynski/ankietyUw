using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace AnkietyUW.DataLayer.Entities
{
    public class Test
    {
        //public string Id { get; set; }
        //[NotMapped]
        //private Guid _guid;
        //[NotMapped]
        //public Guid Guid {
        //    get
        //    {
        //        if (_guid == null || _guid == new Guid())
        //        {
        //            _guid = new Guid(Id);
        //        }
        //        return _guid;
        //    }
        //    set
        //    {
        //        _guid = value;
        //        Id = value.ToString();
        //    }
        //}
        public string Id { get; set; }
        public int FirstQuestionAddSeconds { get; set; }
        public int SecondQuestionAddSeconds { get; set; }
        public int ThirdQuestionAddSeconds { get; set; }
        public int FourthQuestionAddSeconds { get; set; }
        public int CompletedSeriesCounter { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<TestTime> TestTimes { get; set; }

        public int TimeToFillTestAddSeconds { get; set; }
          
    }

    
}
