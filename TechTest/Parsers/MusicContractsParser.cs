using System;
using System.Collections.Generic;
using System.Linq;

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
                yield return new MusicContract()
                {
                    Artist = columns.ElementAt(0),
                    Title = columns.ElementAt(1),
                    Usages = columns.ElementAt(2),
                    StartDate = columns.ElementAt(3),
                    EndDate = columns.ElementAt(4)
                };
            }
        }
    }
}