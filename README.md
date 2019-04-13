# WeRentCar123
 The company WeRentCar123 is looking for a developer to help them build a webpage.In this first version they want to be able to create clients, register vehicles and assign a client to a vehicle.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You will need the have the following technologies installed in your machine to be able to run this project:

```
Visual Studio 2017 or greater
```
```
NetBeans
```
```
SQL Server
```

### Architecture
*Database structure*  
![home](https://raw.githubusercontent.com/BrawnyJavier/WeRentCar123/master/App%20Screenshots/Database.JPG)

*Base app architecture*
![Base app architecture](https://raw.githubusercontent.com/BrawnyJavier/WeRentCar123/master/App%20Screenshots/Base%20app%20architecture.JPG)  

* Report Service : contains the classes and interfaces to connect to the Java service.
* WeRentCar123: is the web project that serves the app.
* WeRentCar123.Context: contains the entityframework's db context.
* WeRentCar123.Models: contains the domain classes.

*ReportServiceJava*
This is a java's RESTful web service that connects to the database and queries a VIEW containing the report's data.
![ReportServiceJava](https://raw.githubusercontent.com/BrawnyJavier/WeRentCar123/master/App%20Screenshots/Report%20Service.JPG)
### Installing


A step by step series of examples that tell you how to get a development env running

### Creating the database 

```
First, you will need to generate the database.
To do so, open the .sln file contained in    .\WeRentCar123\BackOffice\WeRentCar123.sln  
go to WeRentCar123.Context and modify the connection string to match your sql server instance.

using visual studio then, go to  

Tools> Nuget Package Mannager >  Package mannager console    
in the console, select the WeRentCar123.Context as the default project and type "update-database", after  
you hit enter, the database will be created in the configured sql server instance.
```

### Connecting the ReportServer

```
Open the RESTful Java project contained.\WeRentCar123\JavaReportService  
in  using netbeans, you will need to configure  
the database connection, to do so open the persistance.xml file under "Configuration files" folder, change the user and password  
to match your database's user login.  
Second, go to web/web-inf/glassfish-resources and change the parameeters to match  
youur database instance connection.

Run the project.
  

```
### Report filter table plugin
The plugin source file is located at .\WeRentCar123\BackOffice\WeRentCar123\wwwroot\js\WeRentCar123TableFilter.js.  
Usage:  
```
Html: 
<div id="SalesReportTable"></div>
```

```
/// Creates the filtered table
  const TABLE_WITH_FILTER = $('#SalesReportTable').WeRentCar123TableFilter({
            url: '/Report/GetReport'
        });
        
/// Fetches the report, this method also accepts a date parameter,  
// to filter the records.
   TABLE_WITH_FILTER.Fetch();   
```



### Screenshots
![home](https://raw.githubusercontent.com/BrawnyJavier/WeRentCar123/master/App%20Screenshots/Home.JPG)


```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Asp. Net Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2) - The web framework used
* [RESTful web services](https://docs.oracle.com/cd/E24329_01/web.1211/e24983/overview.htm) - Report service
* [JQuery](https://jquery.com/) - Front-end scripting

## Authors

* **Brawny Javier Mateo Reyes** - *Initial work* https://github.com/BrawnyJavier

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments
This project is for demonstration purposes.
