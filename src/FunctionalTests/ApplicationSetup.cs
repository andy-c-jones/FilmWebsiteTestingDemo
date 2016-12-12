using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace FunctionalTests
{
    [SetUpFixture]
    public class ApplicationSetup
    {
        private Process _website;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            _website = StartIis("FilmWishlist", "44342");
            BrowserContext.Start();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            BrowserContext.Stop();
            StopIis(_website);
        }


        private static Process StartIis(string applicationName, string port)
        {
            const string iisExpressPath = @"C:\Program Files\IIS Express\iisexpress.exe";

            if (!File.Exists(iisExpressPath))
                throw new InvalidOperationException("IIS Express not found on filesystem");

            var applicationPath = GetApplicationPath(applicationName);
            Console.WriteLine($"Pointing IIS Express at directory [{applicationPath}]");

            var process = new Process
            {
                StartInfo =
                {
                    FileName = iisExpressPath,
                    Arguments = $"/path:{applicationPath} /port:{port}"
                }
            };
            process.StartInfo.UseShellExecute = false;

            process.Start();
            return process;
        }

        private static void StopIis(Process process)
        {
            if (process.HasExited == false)
            {
                process.Kill();
            }
        }

        private static string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
            return Path.Combine(solutionFolder, $@"src\{applicationName}");
        }
    }
}