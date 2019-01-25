using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTest.Parsers;

namespace TechTest.Tests.ParserTests.MusicContractsParserTests
{
    public class WhenCallingParse: WhenTestingMusicContractsParser
    {
        private string _filename;
        private IEnumerable<MusicContract> _results;

        [SetUp]
        public void When()
        {
            Setup();
            _filename = "filename";

            FileLoader
                .Setup(x => x.Fetch(_filename))
                .Returns(
@"Artist|Title|Usages|StartDate|EndDate
Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|
Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|
Tinie Tempah|Till I'm Gone|digital download|1st Aug 2012|
Monkey Claw|Black Mountain|digital download|1st Feb 2012|
Monkey Claw|Iron Horse|digital download, streaming|1st June 2012|
Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|
Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012");
            
            _results = MusicContractsParser.Parse(_filename);
        }

        [Test]
        public void ItShouldMapArtist()
        {
            Assert.That(_results.ElementAt(0).Artist, Is.EqualTo("Tinie Tempah"));
        }
        
        [Test]
        public void ItShouldMapTitle()
        {
            Assert.That(_results.ElementAt(0).Title, Is.EqualTo("Frisky (Live from SoHo)"));
        }
        
        [Test]
        public void ItShouldMapUsage()
        {
            Assert.That(_results.ElementAt(0).Usages.ElementAt(0), Is.EqualTo("digital download"));
            Assert.That(_results.ElementAt(0).Usages.ElementAt(1), Is.EqualTo("streaming"));
        }
        
        [Test]
        public void ItShouldMapStartDate()
        {
            Assert.That(_results.ElementAt(0).StartDate, Is.EqualTo(new DateTime(2012, 2, 1)));
        }
        
        [Test]
        public void ItShouldMapEndDate()
        {
            Assert.That(_results.ElementAt(0).EndDate, Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void ItShouldMapEndDateWhenNotMissing()
        {
            Assert.That(_results.ElementAt(6).EndDate, Is.EqualTo(new DateTime(2012, 12, 31)));
        }

        [Test]
        public void ItShouldReturnAllRows()
        {
            Assert.That(_results.Count(), Is.EqualTo(7));
        }
    }
}