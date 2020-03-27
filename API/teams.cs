using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace API
{
     public class teams
    {
        [JsonIgnore]
        public int id { get; set; }
        public string School { get; set; }
        //public string mascot { get; set; }
        public string Abbreviation { get; set; }
        //public string alt_name1 { get; set; }
        //public string alt_name2 { get; set; }
        //public string alt_name3 { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        //public string color { get; set; }
        //public string alt_color { get; set; }
        //public List<string> logos { get; set; } 
        public List<coaches> coaches { get; set; } = new List<coaches>();




    }
}
