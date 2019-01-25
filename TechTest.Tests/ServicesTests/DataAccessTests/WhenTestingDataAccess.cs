using System;
using Moq;
using TechTest.Parsers;
using TechTest.Services;

namespace TechTest.Tests.ServicesTests.DataAccessTests
{
    public class WhenTestingDataAccess
    {
        protected IDataAccess DataAccess { get; set; }
        protected Mock<IDistributionPartnerContractsParser> DistributionPartnerContractsParser { get; set; } 
            protected Mock<IMusicContractsParser> MusicContractsParser { get; set; }

        public void Setup()
        {
            MusicContractsParser = new Mock<IMusicContractsParser>();
            DistributionPartnerContractsParser = new Mock<IDistributionPartnerContractsParser>();
            
            DistributionPartnerContractsParser
                .Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(new[]
                {
                    DistributedPartnerContractBuilder.Build.WithPartner("Itunes").WithUsage("stream").AnInstance(),
                    DistributedPartnerContractBuilder.Build.WithPartner("Another").WithUsage("downloads").AnInstance(),
                    DistributedPartnerContractBuilder.Build.WithPartner("AnotherOther").WithUsage("videos").AnInstance()
                });

            MusicContractsParser
                .Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(new[]
                {
                    new MusicContract()
                    {
                        Usages = new[]{"stream","download"},
                        Artist = "artist",
                        EndDate = new DateTime(2001,1,1),
                        StartDate = new DateTime(1999,1,1),
                        Title = "title"
                    }
                });
            
            DataAccess = new DataAccess(
                DistributionPartnerContractsParser.Object,
                MusicContractsParser.Object);
        }
    }
}