# API Testing and Automation Sampling
In this Repo there is a C# API test automation project using Specflow framework.  I have also include a Postman collection I used for exploratory and manual testing.
<br>
<br>
 

## Table of Contents
1. [ API Automation ](#API)
2. [ Postman Collections](#postman)
<br>
<br>
<br>
<a name="API"></a>

## Getting Started with the API Automation Solution
This project contains smoke and functional tests for the JSONPlaceholder API.  Unfortunately, 
the JsonPlaceholder API is just a mocked API with static data and no validation.
Had this been a complete system, these automated tests allow me to spend more time 
on exploratory testing, building test tools and providing larger coverage on a regression suite.
<br>

**Prerequisites**<br>A current version of Visual Studio with C# is required to run these tests.
<br>
https://specflow.org/for-teams/tester/

<br>
**Installing**
1. Fork this Repository on your local computer.
<br>
2. Install all required NuGet packages with the correct versions.
<br>

**Built With**
- SpecFlow
- SpecRun
- ReSharper
- NewtonSoft
- FluentAssertions
- NUnit
- Visual Studio

**Running the Tests**
1. Build the solution to discover the tests.
2. Right click on a single test and select RUN, OR just go for it and click the Run All icon.

NOTE: In my sample, I have an intentionally failing test.
<br>
<br>
<br>

---------------------------------

<a name="postman"></a>

## Getting Started with Postman
This is a collection that I built out to manually explore the JsonPlaceholderAPI.  There are no tests or assertions currently in this collection.  If I had time, I would generally
add them.

**Prerequisites**<br>Postman installed on your computer and basic Postman knowledge. To learn more about Postman, https://learning.postman.com/docs/getting-started/introduction/

**Installing**
1. If you have not done so already, fork this Repository on your local computer.

2. Import the Postman Collection into your personal Workspace.  You should see the folder under your "Collections" and the Environment selected in the top right.

3. With the Environment selected, you can Explore the different API calls in the collection.  Click Send to execute the call.
