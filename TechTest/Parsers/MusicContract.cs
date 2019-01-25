using System;

namespace TechTest.Parsers
{
    public class MusicContract
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Usages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}