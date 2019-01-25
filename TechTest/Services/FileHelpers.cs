using System.IO;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace TechTest.Services
{
    public static class FileHelpers
    {
        public static string GetApplicationPath(string fileName)
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher=new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(.*)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var path = Path.Combine(appRoot, fileName);
            if(File.Exists(path))
                return path;
            
            exePath = exePath.Substring(5, exePath.IndexOf("TechTest") + 3) + "/TechTest";
            path = exePath + fileName;
            return path;
        }
    }
}