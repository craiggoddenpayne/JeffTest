using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TechTest.Parsers;

namespace TechTest.Tests.ParserTests.DistributionPartnerContractsParserTests
{
    public class WhenCallingParse: WhenTestingDistributionPartnerContractsParser
    {
        private string _filename;
        private IEnumerable<DistributedPartnerContract> _results;

        [SetUp]
        public void When()
        {
            Setup();
            _filename = "filename";

            FileLoader
                .Setup(x => x.Fetch(_filename))
                .Returns(
@"Partner|Usage
ITunes|digital download
YouTube|streaming");
            
            _results = DistributionPartnerContractsParser.Parse(_filename);
        }

        [Test]
        public void ItShouldMapPartner()
        {
            Assert.That(_results.ElementAt(0).Partner, Is.EqualTo("ITunes"));
        }
        
        [Test]
        public void ItShouldMapUsage()
        {
            Assert.That(_results.ElementAt(0).Usage, Is.EqualTo("digital download"));
        }

        [Test]
        public void ItShouldReturnAllRows()
        {
            Assert.That(_results.Count(), Is.EqualTo(2));
        }
    }
}