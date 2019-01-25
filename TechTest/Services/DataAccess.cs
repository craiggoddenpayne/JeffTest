using System.Collections.Generic;
using System.IO;
using TechTest.Parsers;

namespace TechTest.Services
{
    public class DataAccess : IDataAccess
    {
        private IEnumerable<DistributedPartnerContract> _distributionPartners;
        private IEnumerable<MusicContract> _musicContracts;

        public DataAccess(IDistributionPartnerContractsParser distributionPartnerContractsParser,
            IMusicContractsParser musicContractsParser)
        {
            var dataDir = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "data");
            
            _distributionPartners = distributionPartnerContractsParser.Parse(dataDir + "/distribution-partner-contracts.txt");
            _musicContracts = musicContractsParser.Parse("/music-contracts.txt");
        }
        
        public IEnumerable<MusicContract> GetMusicContractsFor()
        {
            return null;
        }
    }
}