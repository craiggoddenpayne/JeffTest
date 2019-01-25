using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TechTest.Parsers;

namespace TechTest.Tests.ServicesTests.DataAccessTests
{
    public class WhenCallingQueryAndNoMatchWithinDateRange : WhenTestingDataAccess
    {
        private IEnumerable<MusicContractResult> _result;

        [SetUp]
        public void When()
        {
            Setup();

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
                        Usages = new[] {"stream", "download"},
                        Artist = "artist",
                        EndDate = new DateTime(2001,1,1),
                        StartDate = new DateTime(2000,6,1),
                        Title = "title"
                    }
                });

            _result = DataAccess.Query("Itunes", new DateTime(1970, 01, 01));
        }

        [Test]
        public void ItShouldReturnNoResults()
        {
            Assert.That(_result.Count(), Is.EqualTo(0));
        }
    }
}