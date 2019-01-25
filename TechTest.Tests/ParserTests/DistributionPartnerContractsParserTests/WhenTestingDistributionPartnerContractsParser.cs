using Moq;
using TechTest.Parsers;

namespace TechTest.Tests.ParserTests.DistributionPartnerContractsParserTests
{
    public class WhenTestingDistributionPartnerContractsParser
    {
        protected IDistributionPartnerContractsParser DistributionPartnerContractsParser { get; set; }
        protected Mock<IFileLoader> FileLoader { get; set; }
        
        public void Setup()
        {
            FileLoader = new Mock<IFileLoader>();
            
            DistributionPartnerContractsParser = new DistributionPartnerContractsParser(
                FileLoader.Object);
        }
    }
}