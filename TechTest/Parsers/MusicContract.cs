using System;
using System.Collections.Generic;

namespace TechTest.Parsers
{
    public class MusicContract
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Usages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}