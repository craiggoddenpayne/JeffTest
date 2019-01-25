using System.Collections.Generic;

namespace TechTest.Parsers
{
    public interface IMusicContractsParser
    {
        IEnumerable<MusicContract> Parse(string filename);
    }
}