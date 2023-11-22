# Solution

This solution is a simple web application that allows users to view and edit a list of products. The solution is composed of two projects:

- **Backend**: A .NET 6 Web API project that exposes a RESTful API to manage products.
- **Frontend**: An Angular 16.2.0 project that provides a user interface to interact with the backend.

## Backend

The backend project is a .NET 6 Web API project that exposes a RESTful API to manage products. The project is composed of the following folders:

- **Controllers**: Contains the controllers that expose the RESTful API.
- **Data**: Contains the data access layer.
- **Models**: Contains the models used by the controllers and the data access layer.
- **Properties**: Contains the launchSettings.json file, which is used to configure the application when it is launched from Visual Studio.
- **appsettings.json**: Contains the configuration settings for the application.
- **Program.cs**: Contains the entry point for the application.
- **ProductsApi.csproj**: Contains the project configuration.
- **README.md**: Contains the documentation for the project.

## Frontend

The frontend project is an Angular 16.2.0 project that provides a user interface to interact with the backend. The project is composed of the following folders:

- **src/app**: Contains the components, services, and models used by the application.
- **src/assets**: Contains the images used by the application.
- **src/index.html**: Contains the HTML file that is used as the entry point for the application.
- **src/main.ts**: Contains the entry point for the application.
- **src/styles.css**: Contains the global styles used by the application.
- **src/tsconfig.app.json**: Contains the TypeScript configuration for the application.
- **src/tsconfig.json**: Contains the TypeScript configuration for the project.
- **src/tsconfig.spec.json**: Contains the TypeScript configuration for the tests.
- **angular.json**: Contains the Angular configuration for the project.
- **karma.conf.js**: Contains the configuration for the Karma test runner.
- **package.json**: Contains the dependencies for the project.
- **README.md**: Contains the documentation for the project.

## Getting Started

To get started, you will need to clone the repository to your local machine. Once cloned, you can open the solution in Visual Studio 2022 Preview 4.1 and run the application. Alternatively, you can run the frontend and backend projects separately.

### Running the Application

Before running the application, you need to setup the startup projects in Visual Studio. To do this, right-click on the solution in the Solution Explorer and select **Set Startup Projects...**. In the dialog that appears, select **Multiple startup projects** and set the **Action** for both the **Backend** and **Frontend** projects to **Start**. Click **OK** to save the changes.
