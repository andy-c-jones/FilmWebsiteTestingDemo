# FilmWebsiteTestingDemo
A demo of different types of test (Unit, Integration, Contract, Functional)

## Prerequisites
* Visual Studio 2015+ & Resharper (Lastest) OR Jetbrains Rider
* Microsoft SQL Server 2012 or later (with permissions set up for your windows user)


## Setup
To use the project execute the "SetupDatabase.sql" script against you local database instance of MS SQL Server.

Open the solution and run all tests with your IDE to make sure it all works.

## Contract tests
To run the contract tests you must first rebuild the whole project inside you IDE you can then run either of the scripts in a powershell session:
* ``./runContractTestsAgainstFakeServices.ps1`` will run the contract tests against the fakes
* ``./runContractTestsAgainstRealServices.ps1`` will run the contract tests against the real services
Remember to rebuild your solution each time you want to run your contract tests from outside your IDE!

## Other resources used in this project
* [NUnit](https://github.com/nunit/nunit) - NUnit is a unit-testing framework for all .Net languages.
* [Moq](https://github.com/moq/moq) - The most popular and friendly mocking framework for .NET
* [pact-net](https://github.com/SEEK-Jobs/pact-net) - .NET version of Pact. Enables consumer driven contract testing, providing a mock service and DSL for the consumer project, and interaction playback and verification for the service provider project.
* [RestSharp](https://github.com/restsharp/RestSharp) - Simple REST and HTTP API Client for .NET
* [Dapper](https://github.com/StackExchange/dapper-dot-net) - A simple object mapper for .Net (Adds extensions to IDbConnection).
* [Bootstrap](http://getbootstrap.com/) - Bootstrap is the most popular HTML, CSS, and JS framework for developing responsive, mobile first projects on the web.
* [OMDb API](https://www.omdbapi.com/) - The OMDb API is a free web service to obtain movie information, all content and images on the site are contributed and maintained by our users.



## Todo
* Add a proper build script so remembering to rebuild all each time before running contracts against real services is not a problem
