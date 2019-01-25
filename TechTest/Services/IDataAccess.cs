using System;
using System.Collections.Generic;
using TechTest.Parsers;

namespace TechTest.Services
{
    public interface IDataAccess
    {
        IEnumerable<MusicContract> Query(string deliveryPartner, DateTime effectiveDate);
    }
}