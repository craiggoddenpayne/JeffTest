using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TechTest.Parsers;

namespace TechTest.Tests.ServicesTests.DataAccessTests
{
    public class WhenCallingQueryAndMatchWithinDateRange : WhenTestingDataAccess
    {
        private IEnumerable<MusicContractResult> _result;

        [SetUp]
        public void When()
        {
            Setup();
            _result = DataAccess.Query("Itunes", new DateTime(2000, 01, 01));
        }

        [Test]
        public void ItShouldJoinMatchAndReturnUsages()
        {
            Assert.That(_result.ElementAt(0).Usage, Is.EqualTo("stream"));
        }
        
        [Test]
        public void ItShouldJoinMatchAndReturnArtist()
        {
            Assert.That(_result.ElementAt(0).Artist, Is.EqualTo("artist"));
        }
        
        [Test]
        public void ItShouldJoinMatchAndReturnTitle()
        {
            Assert.That(_result.ElementAt(0).Title, Is.EqualTo("title"));
        }
    }
}