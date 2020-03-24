using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class coaches
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
