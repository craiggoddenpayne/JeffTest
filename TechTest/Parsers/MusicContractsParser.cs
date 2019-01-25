using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace TechTest.Parsers
{
    public class MusicContractsParser : IMusicContractsParser
    {
        private readonly IFileLoader _fileLoader;

        public MusicContractsParser(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public IEnumerable<MusicContract> Parse(string filename)
        {
            var data = _fileLoader.Fetch(filename);
            var rows = data.Split(Environment.NewLine);
            foreach (var row in rows.Skip(1))
            {    
                var columns = row.Split("|");
                yield return new MusicContract
                {
                    Artist = columns.ElementAt(0),
                    Title = columns.ElementAt(1),
                    Usages = columns.ElementAt(2),
                    StartDate = ConvertDate(columns.ElementAt(3)),
                    EndDate = ConvertDate(columns.ElementAt(4))
                };
            }
        }

        private DateTime ConvertDate(string dateFormat)
        {
            if(dateFormat == "")
                return DateTime.MaxValue;
            
            var startDayMonthYear = Regex.Match(dateFormat, "(\\d{1,2}).*\\s(\\w{3,}|\\w{4,})\\s(\\d\\d\\d\\d)").Groups;
            var day = int.Parse(startDayMonthYear.ElementAt(1).Value);
            var month = DateTime.ParseExact(startDayMonthYear.ElementAt(2).Value.Substring(0, 3), "MMM", CultureInfo.CurrentCulture).Month;
            var year = int.Parse(startDayMonthYear.ElementAt(3).Value);
            return new DateTime(year, month, day);
        }
    }
}