# Holiday Search API

## Brief

Taking two JSON files of flights and hotels as source data, create a small library of code that provides a basic holiday search feature. 

## Goal

The goal of this exercise is to build a web client that interacts with this API. 
It should be able to send different parameters to the API, and display the best value holiday package.

## Approach

Built using .NET Core, the solution follows Clean Architecture and implements the Mediatr CQRS pattern. The database `json` files are stored within the Infrastructure layer. The Presentation layer utilises the Swagger UI.

There are four layers to the solution:

- Presentation Layer
- Application Layer
- Domain Layer
- Infrastructure Layer

The solution also follows TDD principles and the tests can be found in the `OTB.HolidaySearch.Tests` solution. Tests were written with NUnit.

## Guidance

- When searching cities, the available cities are: London, Manchester, Mallorca, Malaga, Tenerife, Las Palmas.
- When searching Travelling To destination & Travelling From destinations, the available airports are: LGW, LTN, MAN, PMI, AGP, TFS, LPA
- When searching dates, the input will be `YYYY/MM/DD`

## Future Improvements
- Logging
- Validation for each request, ensuring each parameter only accepts specific formats
- End-to-end testing to check full implementation from controller action all through to `.json` file
- Improved inheritance by storing repeated code in a `BaseRequestHandler`
- Improve the display names for request parameters within tthe Swagger UI
- Handle 'unhappy paths' with improved exception handling 
