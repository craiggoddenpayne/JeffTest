using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTest.Parsers;

namespace TechTest.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IEnumerable<DistributedPartnerContract> _distributionPartners;
        private readonly IEnumerable<MusicContract> _musicContracts;

        public DataAccess(IDistributionPartnerContractsParser distributionPartnerContractsParser,
            IMusicContractsParser musicContractsParser)
        {
            var dataDir = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "data");
            
            _distributionPartners = distributionPartnerContractsParser.Parse(dataDir + "/distribution-partner-contracts.txt");
            _musicContracts = musicContractsParser.Parse("/music-contracts.txt");
        }
        
        public IEnumerable<MusicContract> Query(string deliveryPartner, DateTime effectiveDate)
        {
            var deliveryPartners = _distributionPartners.Where(x => x.Partner == deliveryPartner);
            return _musicContracts
                .Where(x => deliveryPartners.Any(y => y.Usage == x.Usages))
                .Where(x => effectiveDate > x.StartDate)
                .Where(x => effectiveDate < x.EndDate);
        }
    }
}