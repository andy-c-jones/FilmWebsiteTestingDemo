# FilmWebsiteTestingDemo
A demo of different types of test (Unit, Integration, Contract, Functional)

##Prerequisites
* Visual Studio 2015+ & Resharper (Lastest) OR Jetbrains Rider
* Microsoft SQL Server 2012 or later (with permissions set up for your windows user)


##Setup
To use the project execute the "SetupDatabase.sql" script against you local database instance of MS SQL Server.

Open the solution and run all tests with your IDE to make sure it all works.

#Contract tests
To run the contract tests you must first rebuild the whole project inside you IDE you can then run either of the scripts in a powershell session:
* ``./runContractTestsAgainstFakeServices.ps1`` will run the contract tests against the fakes
* ``./runContractTestsAgainstFakeServices.ps1`` will run the contract tests against the real services
Remember to rebuild your solution each time you want to run your contract tests from outside your IDE!

#Todo
* Add a proper build script so remembering to rebuild all each time before running contracts against real services is not a problem