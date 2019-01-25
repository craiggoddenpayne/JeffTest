using System;
using System.Linq;
using NUnit.Framework;
using TechTest.Parsers;
using TechTest.Services;

namespace TechTest.Tests
{
    public class Scenarios
    {
        [Test]
        public void Scenario1()
        {
            //Given the supplied above reference data
            var fileLoader = new FileLoader();
            var dataAccess = new DataAccess(
                new DistributionPartnerContractsParser(fileLoader),
                new MusicContractsParser(fileLoader));

            //When user enters 'ITunes 1st March 2012'   
            var result = dataAccess.Query("ITunes", new DateTime(2012, 3, 1));
                           
            //Then the output is:
            //Artist|Title|Usage|StartDate|EndDate
            //Monkey Claw|Black Mountain|digital download|1st Feb 2012|
            //Monkey Claw|Motor Mouth|digital download|1st Mar 2011|
            //Tinie Tempah|Frisky (Live from SoHo)|digital download|1st Feb 2012|
            //Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|

            Assert.That(result.Count(), Is.EqualTo(4));
            
            Assert.That(result.ElementAt(0).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(0).Title, Is.EqualTo("Black Mountain"));
            Assert.That(result.ElementAt(0).Usage, Is.EqualTo("digital download"));
            Assert.That(result.ElementAt(0).StartDate, Is.EqualTo(new DateTime(2012,2,1)));
            Assert.That(result.ElementAt(0).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(1).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(1).Title, Is.EqualTo("Motor Mouth"));
            Assert.That(result.ElementAt(1).Usage, Is.EqualTo("digital download"));
            Assert.That(result.ElementAt(1).StartDate, Is.EqualTo(new DateTime(2011,3,1)));
            Assert.That(result.ElementAt(1).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(2).Artist, Is.EqualTo("Tinie Tempah"));
            Assert.That(result.ElementAt(2).Title, Is.EqualTo("Frisky (Live from SoHo)"));
            Assert.That(result.ElementAt(2).Usage, Is.EqualTo("digital download"));
            Assert.That(result.ElementAt(2).StartDate, Is.EqualTo(new DateTime(2012,2,1)));
            Assert.That(result.ElementAt(2).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(3).Artist, Is.EqualTo("Tinie Tempah"));
            Assert.That(result.ElementAt(3).Title, Is.EqualTo("Miami 2 Ibiza"));
            Assert.That(result.ElementAt(3).Usage, Is.EqualTo("digital download"));
            Assert.That(result.ElementAt(3).StartDate, Is.EqualTo(new DateTime(2012,2,1)));
            Assert.That(result.ElementAt(3).EndDate, Is.EqualTo(DateTime.MaxValue));
            
        }
    }
}