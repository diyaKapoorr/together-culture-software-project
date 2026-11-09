# Together Culture Member Space

A C# Windows Forms software engineering project developed as a university team project for **Together Culture**.

The application provides member-facing and administrative functionality for managing a community membership platform.

## Features

- Member and admin authentication
- Member registration and account management
- Member and staff search
- Member and admin dashboards
- Events and event booking
- Interactive calendar
- Billing and payment information
- Feedback and contact-admin workflows
- Blog and digital content
- Collaboration and community features
- Shop and purchase interfaces
- Member insights and administrative reporting

## Technology

- C#
- Windows Forms
- .NET Framework 4.7.2
- MySQL
- Visual Studio
- NuGet packages including MySql.Data, Newtonsoft.Json and Bunifu UI components

## Project Structure

The repository contains the Visual Studio solution, C# source files, Windows Forms designer files, resources and package configuration.

Main entry point:

```text
Program.cs
```

Visual Studio solution:

```text
member space.sln
```

## Running the Project

1. Open `member space.sln` in Visual Studio.
2. Restore the NuGet dependencies.
3. Configure a local MySQL database named `together_culture`.
4. Recreate the required database tables/schema used by the application.
5. Update the local database connection configuration if required.
6. Build and run the solution.

> The original project did not include a database schema export, so database recreation is required before all features can run.

## Application Screenshots

### Home Page
![Together Culture Home Page](screenshots/home-page.png)

### Member Dashboard
![Member Dashboard](screenshots/member-dashboard.png)

### Admin Dashboard
![Admin Dashboard](screenshots/admin-dashboard.png)

### Member Insights
![Member Insights Dashboard](screenshots/member-insights.png)

## Portfolio Note

This repository is a cleaned portfolio snapshot of a university **team software engineering project**. Visual Studio cache files, build outputs, NuGet package caches and the previous Git repository metadata have been excluded.

## Security / Production Limitations

This is an educational prototype rather than a production-ready application. A production implementation should:

- store database connection settings outside source files;
- use environment-specific configuration/secrets management;
- hash and salt user passwords rather than storing them directly;
- add stronger validation, error handling and automated tests;
- include database migrations or a reproducible schema setup.

## Contributors

This project was completed collaboratively as part of a university software engineering project. The repository is published here as a portfolio snapshot of the work.
