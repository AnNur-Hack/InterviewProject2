 Country Lookup API

A simple ASP.NET Core Web API built with C#, Entity Framework Core, and SQLite to identify a country's calling code from a phone number and return its country and associated mobile operators.

 Technologies

* C# / ASP.NET Core 8 Web API
* Entity Framework Core
* SQLite In-Memory Database
* Swagger / OpenAPI

 Features

* Accepts phone numbers through a GET endpoint.
* Identifies the country using its calling code.
* Returns country information and associated mobile operators.
* Validates phone number input.
* Uses a repository and service layer for separation of concerns.
* Seeds country and operator data automatically at startup.

 API Endpoint

GET `/api/Countries/{phoneNumber}`

Example:

`GET /api/Countries/2348167071177`

The response includes the phone number, country calling code, country name, ISO code, and associated operators.

 Running the Project

1. Clone the repository.
2. Open the project in JetBrains Rider or Visual Studio.
3. Restore NuGet packages.
4. Run the application.
5. Open Swagger to test the endpoint.

> Note: The SQLite in-memory database is recreated whenever the application restarts.


