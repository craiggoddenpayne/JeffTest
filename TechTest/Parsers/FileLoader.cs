using System.IO;

namespace TechTest.Parsers
{
    public class FileLoader : IFileLoader
    {
        public string Fetch(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}