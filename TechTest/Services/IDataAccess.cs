using System.Collections.Generic;
using TechTest.Parsers;

namespace TechTest.Services
{
    public interface IDataAccess
    {
        IEnumerable<MusicContract> GetMusicContractsFor();
    }
}