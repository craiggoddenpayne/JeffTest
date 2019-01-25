using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Parsers;

namespace TechTest.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IEnumerable<DistributedPartnerContract> _distributionPartners;
        private readonly IEnumerable<MusicContract> _musicContracts;

        public DataAccess(
            IDistributionPartnerContractsParser distributionPartnerContractsParser,
            IMusicContractsParser musicContractsParser)
        {
            _distributionPartners = distributionPartnerContractsParser.Parse(FileHelpers.GetApplicationPath("/data/distribution-partner-contracts.txt"));
            _musicContracts = musicContractsParser.Parse(FileHelpers.GetApplicationPath("/data/music-contracts.txt"));
        }
        
        public IEnumerable<MusicContractResult> Query(string deliveryPartner, DateTime effectiveDate)
        {
            var partner = _distributionPartners.FirstOrDefault(x => string.Equals(x.Partner, deliveryPartner, StringComparison.CurrentCultureIgnoreCase));
            if (partner == null)
                return new MusicContractResult[0];
            
            return _musicContracts
                .Where(x => x.Usages.Contains(partner.Usage))
                .Where(x => effectiveDate > x.StartDate)
                .Where(x => effectiveDate < x.EndDate)
                .OrderBy(x => x.Artist)
                .ThenBy(x => x.Title)
                .Select(x => new MusicContractResult
                {
                    Artist = x.Artist,
                    Usage = partner.Usage,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    Title = x.Title
                });
        }
    }
}