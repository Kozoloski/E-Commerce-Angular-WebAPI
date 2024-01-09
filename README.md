
# PlantShop FullStack E-Commerce Website

Welcome to the PlantShop E-Commerce Website, where you can find your favorite plants. 

This is an ongoing project where I contribute daily by adding new features and functionalities.

This application uses Angular for the Front-End and ASP.NET Core for the Back-End. The data is stored in the SQL Server database. 

## Getting Started

These instructions will help you set up a local copy of the project on your machine.

### Prerequisites

Make sure you have the following installed on your machine:

- [Node.js](https://nodejs.org/) (with npm)
- [Angular CLI](https://cli.angular.io/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://docs.docker.com/get-docker/)

### Clone the Repository

- https://github.com/Kozoloski/E-Commerce-Angular-WebAPI.git
- Open the server side with Visual Studio
- Open the client side with Visual Studio Code
- You can find additional info about the Angular part in the readme file located in the client folder in this Repository

### Docker and Redis Integration

- Navigate to the project directory: cd E-Commerce-Angular-WebAPI
- Start the Docker containers using Docker Compose: docker-compose up
- This command will download the necessary Docker images, build the application containers, and start the services.
- Redis Commander is accessible at [http://localhost:8081](http://localhost:8081) with the username `root` and password `secret`.

### Database Setup

- Modify the connection string configured in appsettings.json for your database. 
- Change the paths in StoreContextSeed to be aligned with your local machine, or make them relative.
- Add migration and update database.

I will update the readme file with a more detailed version whenever I add new functionalities.
  
