using System;
using System.Linq;
using NUnit.Framework;
using TechTest.Parsers;
using TechTest.Services;

namespace TechTest.Tests
{
    public class Scenarios
    {
        private DataAccess _dataAccess;

        [SetUp]
        public void Setup()
        {
            var fileLoader = new FileLoader();
            _dataAccess = new DataAccess(
                new DistributionPartnerContractsParser(fileLoader),
                new MusicContractsParser(fileLoader));
        }
        
        [Test]
        public void Scenario1()
        {
            //Given the supplied above reference data
            //When user enters 'ITunes 1st March 2012'   
            var result = _dataAccess.Query("ITunes", new DateTime(2012, 3, 1));
                           
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


        [Test]
        public void Scenario2()
        {
//            Given the supplied above reference data
//            When user enters 'YouTube 1st April 2012'
            var result = _dataAccess.Query("YouTube", new DateTime(2012, 4, 1));
//            Then the output is:
//            Artist|Title|Usage|StartDate|EndDate
//            Monkey Claw|Motor Mouth|streaming|1st Mar 2011|
//            Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|
            Assert.That(result.Count(), Is.EqualTo(2));
            
            Assert.That(result.ElementAt(0).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(0).Title, Is.EqualTo("Motor Mouth"));
            Assert.That(result.ElementAt(0).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(0).StartDate, Is.EqualTo(new DateTime(2011,3,1)));
            Assert.That(result.ElementAt(0).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(1).Artist, Is.EqualTo("Tinie Tempah"));
            Assert.That(result.ElementAt(1).Title, Is.EqualTo("Frisky (Live from SoHo)"));
            Assert.That(result.ElementAt(1).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(1).StartDate, Is.EqualTo(new DateTime(2012,2,1)));
            Assert.That(result.ElementAt(1).EndDate, Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void Scenario3()
        {
//            Given the supplied above reference data
//            When user enters 'YouTube 27th Dec 2012'
            var result = _dataAccess.Query("YouTube", new DateTime(2012, 12, 27));
//            Then the output is:
//            Artist|Title|Usage|StartDate|EndDate
//            Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012
//            Monkey Claw|Iron Horse|streaming|1st June 2012|
//                Monkey Claw|Motor Mouth|streaming|1st Mar 2011|
//                Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|
            
            Assert.That(result.Count(), Is.EqualTo(4));
            
            Assert.That(result.ElementAt(0).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(0).Title, Is.EqualTo("Christmas Special"));
            Assert.That(result.ElementAt(0).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(0).StartDate, Is.EqualTo(new DateTime(2012,12,25)));
            Assert.That(result.ElementAt(0).EndDate, Is.EqualTo(new DateTime(2012,12,31)));
            
            Assert.That(result.ElementAt(1).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(1).Title, Is.EqualTo("Iron Horse"));
            Assert.That(result.ElementAt(1).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(1).StartDate, Is.EqualTo(new DateTime(2012,6,1)));
            Assert.That(result.ElementAt(1).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(2).Artist, Is.EqualTo("Monkey Claw"));
            Assert.That(result.ElementAt(2).Title, Is.EqualTo("Motor Mouth"));
            Assert.That(result.ElementAt(2).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(2).StartDate, Is.EqualTo(new DateTime(2011,3,1)));
            Assert.That(result.ElementAt(2).EndDate, Is.EqualTo(DateTime.MaxValue));
            
            Assert.That(result.ElementAt(3).Artist, Is.EqualTo("Tinie Tempah"));
            Assert.That(result.ElementAt(3).Title, Is.EqualTo("Frisky (Live from SoHo)"));
            Assert.That(result.ElementAt(3).Usage, Is.EqualTo("streaming"));
            Assert.That(result.ElementAt(3).StartDate, Is.EqualTo(new DateTime(2012,2,1)));
            Assert.That(result.ElementAt(3).EndDate, Is.EqualTo(DateTime.MaxValue));
        }
    }
}