using Moq;
using TechTest.Parsers;

namespace TechTest.Tests.ParserTests.MusicContractsParserTests
{
    public class WhenTestingMusicContractsParser
    {
        protected IMusicContractsParser MusicContractsParser { get; set; }
        protected Mock<IFileLoader> FileLoader { get; set; }
        
        public void Setup()
        {
            FileLoader = new Mock<IFileLoader>();
            
            MusicContractsParser = new MusicContractsParser(
                FileLoader.Object);
        }
    }
}