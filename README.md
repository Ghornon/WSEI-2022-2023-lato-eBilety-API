# eBilety - Cinema Ticket Booking App

This is an e-ticket booking application for a cinema, developed as a study project using ASP.NET Core. The application allows users to browse through available movies and book a ticket for a specific showtime.

# Final project

Final project of backend programming using ASP.NET CORE

## Subject

L/23 N lab2/2PROG Programowanie aplikacji back-endowych

## Creators
- Szymon Guzik
- Mateusz Dynur
- Patryk Domagała

# Docs

## Features
The application provides the following features:

1. rowse Movies: Users can browse through the list of available movies and view their details.
2. Showtimes and Ticket Booking: Users can view the showtimes for a movie and select a showtime to book tickets.
3. Ticket Management: Users can view their booked tickets.
4. Admin Functionality: Admin users have additional privileges to add, edit, and delete movies, showtimes, actors, and producers in the cinema hall.

## Technologies Used
The application is developed using the following technologies:

- ASP.NET Framework
- C#
- Swagger
- SQL Server
- Docker

## Installation
To install and run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file eTicket.sln in Visual Studio.
3. Restore the NuGet packages used in the project.
4. Run SQL Server Management Studio
5.  Open the ***appsettings.js*** and change the connection string to connect to your local instance of SQL Server. Example:
```JSON
DevConnection": "Server=localhost\\SQLEXPRESS;Database=eBilety;TrustServerCertificate=True;Trusted_Connection=True;"
```
7. Build and run the application.

## Running inside docker

1. Clone the repository to your local machine.
2. Navigate to "./eBilety API"
3. Run docker run .

## Running compose

1. Clone the repository to your local machine.
2. Docker compose uses eBilety-GUI repo
3. Clone https://github.com/mateuszd47/ebilety-gui
4. Navigate to ***ebilety-gui***
5. Build docker image
```bash
docker build -t ghornon/ebilety-gui .
```
6. Open ***ebilety-api*** directory
3. Run docker compose up

### Usage
To use the application, please follow these steps:

1. Open the application in your web browser. The default GUI can be accessed at http://localhost, and the API at http://localhost:8080.
2. Browse through the list of available movies and select a movie to view its details.
3. Select a showtime to book tickets.
4. Choose your preferred seats in the cinema hall.
5. Confirm your booking.
6. You can view your booked tickets on the "All Orders" page.
Admin users can add, edit, and delete movies, actors, producers, and showtimes in the cinema hall by logging in with their credentials.

## Built-in users

The application includes the following pre-configured users:

### Administrator
- Login: admin@gmail.com
- Password: Admin@1234!

### User
- Login: jan.kowalski@gmail.com
- Password: Janek@1234!

## Contributing
Feel free to contribute to this project.

## License
This project is licensed under the GNU Affero General Public License v3.0. See the LICENSE file for details.