using System;

namespace TechTest.Tests.ServicesTests.DataAccessTests
{
    public abstract class Builder<TBuilder, TBuildType>
    {
        public static TBuilder Build => Activator.CreateInstance<TBuilder>();
        public abstract TBuildType AnInstance();
    }
}