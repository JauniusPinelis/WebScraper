# Work in It

A project to scrape data from job websites and display in a proper/comfortable format.
The aim is to have something similar to https://remoteok.io/

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them

- [node.js](https://nodejs.org/) - for npm and front app
- [.net core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)- web api and data data scraping service

### To scrape Data

- Modify "DefaultConnectionString" to point to your local db instance
- Run update-database
- Run "Webscraper.Console" project

### To run the App

- Modify "DefaultConnectionString" to point to your local db instance
- Run WebApi/WebApi.Api
- cd to /ClientApp/
- npm install
- npm run start

## Built With

- [.net core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)- web api and data data scraping service
- [React](https://reactjs.org/) - Front-end framework

## Contributing

To be added

## Authors

- **Jaunius Pinelis** - _Initial work_

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.
