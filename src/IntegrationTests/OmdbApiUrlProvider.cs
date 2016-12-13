using System;
using System.Collections;

namespace IntegrationTests
{
    public class OmdbApiUrlProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var environment = Environment.GetEnvironmentVariable("ContractTestRealServices");
            if (!string.IsNullOrEmpty(environment))
                yield return "http://www.omdbapi.com/";
            yield return "http://localhost:5842/";
        }
    }
}