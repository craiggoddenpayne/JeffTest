using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TechTest.Parsers
{
    public class DistributionPartnerContractsParser : IDistributionPartnerContractsParser
    {
        private readonly IFileLoader _fileLoader;

        public DistributionPartnerContractsParser(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public IEnumerable<DistributedPartnerContract> Parse(string filename)
        {
            var data = _fileLoader.Fetch(filename);
            var rows = data.Split(Environment.NewLine);
            foreach (var row in rows)
            {
                var columns = row.Split("|");
                yield return new DistributedPartnerContract
                {
                    Partner = columns.ElementAt(0),
                    Usage = columns.ElementAt(1)
                };
            }
        }
    }
}