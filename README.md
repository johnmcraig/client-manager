# Client Manager

> Clean architecture application in ASP.Net Core 3.1 and Vue.js

## Demo

Demo coming soon.

## Scope

This is a management application built using ASP.Net Core 3.1, structured using Robert C. Martin's Clean Code principles. Namely the domain centric universe with all other projects referencing inward towards the entity library.

## Tech and Tools

- C#/ASP.Net Core 3.1
- Vue.js 2.6.11
- MediatR NuGet package for CQRS pattern
- SQL Server (easily configurable for PostgreSQL or MySQL)

## Project Structure

The project is housed in a source folder named `src/` that contains five subdirectories as different project libraries designed as their specific functionality.

`ClientManager.Api` is the web Api and controllers.

`~.Data` houses configuration for the database, Entity Framework migrations, and mock data to be seeded on first time startup to the database.

`~.Application` contains methods that carry out the main functions implemented in the controllers to keep them "thin".

`~.Domain` is the center of the project universe, containing only entity classes.

And finally, there is the `client-vue` folder that contains the files that act as the views and UI for the application, primarily written in Vue.js.

## Installation

## Database Setup

## TODO

### Contributing
