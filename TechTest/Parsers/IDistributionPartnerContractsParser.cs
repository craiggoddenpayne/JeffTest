using System.Collections.Generic;

namespace TechTest.Parsers
{
    public interface IDistributionPartnerContractsParser
    {        
        IEnumerable<DistributedPartnerContract> Parse(string filename);
    }
}