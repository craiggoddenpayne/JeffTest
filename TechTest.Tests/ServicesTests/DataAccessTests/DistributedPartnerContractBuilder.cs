using TechTest.Parsers;

namespace TechTest.Tests.ServicesTests.DataAccessTests
{   
    public class DistributedPartnerContractBuilder : Builder<DistributedPartnerContractBuilder, DistributedPartnerContract>
    {
        private string _partner = "Partner";
        private string _usage = "Usage";

        public override DistributedPartnerContract AnInstance()
        {
            return new DistributedPartnerContract
            {
                Partner = _partner,
                Usage = _usage
            };
        }

        public DistributedPartnerContractBuilder WithPartner(string partner)
        {
            _partner = partner;
            return this;
        }
        
        public DistributedPartnerContractBuilder WithUsage(string usage)
        {
            _usage = usage;
            return this;
        }
    }
}