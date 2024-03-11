# Travel Through Colombia ✈️🛫👨‍✈️

This project serves as a comprehensive solution for a travel company aiming to facilitate seamless travel connections within Colombia. The system calculates the journey based on the origin and destination provided by the user.

## Features
- **Flights Retrieval**: Retrieve a list of different flights obtained through the API.
- **Route Calculation**: Calculate the route for a journey using the API, ensuring accurate and efficient travel planning.

## Technologies Used
- **.NET 7 SDK**: Utilized for backend development.
- **MySQL**: Used for database management and storage.
- **Entity Framework Core**: Employed for ORM (Object-Relational Mapping) to interact with the database.
- **AutoMapper**: Facilitates object-to-object mapping.
- **ASP.NET Core MVC**: Framework used for building web APIs.
- **Newtonsoft.Json**: Used for JSON serialization/deserialization.

## Setup Instructions
1. **Clone the Repository**: Clone the project repository to your local machine.
2.   Update the connection string in `appsettings.json` with the database details.
3. **Database Configuration**:
   - Create the database in MySQL using the migration posted in the project.
       ``` c#
        dotnet ef database update -s .\API\ -p .\DataAccess\
        ```

3. **Execution**:
   - Compile the project.
   - Run the project from Visual Studio or via the command line.
        ``` c#
        dotnet run --project ./API/
        ```

## Endpoints and Usage
- **Retrieve Flights**: 
  - **Method**: GET
  - **Endpoint**: `http://localhost:5184/api/flight/`
  - **Body**: null

- **Calculate Route**:
  - **Method**: GET
  - **Endpoint**: `http://localhost:5184/api/journey/`
  - **Body**:
    ```json
    {
      "Origin": "Starting point of the journey",
      "Destination": "Final destination of the journey"
    }
    ```

## Author
- [@DevJLeon](https://github.com/DevJLeon)

This project aims to simplify travel planning within Colombia by providing accurate route calculation and flight information retrieval capabilities. It leverages modern .NET technologies to deliver a robust and efficient solution.

