# Hiking Trails API

#### By: Katie Pundt, Liz Thomas, and Kim Brannian

#### _An API to find hiking trails._

## Technologies Used
* C#
* .NET5
* NuGet
* ASP.NET Core
* Swagger
* git
* GitHub
* MySQL
* MySQL Workbench

## Description
_Based on the book "60 Hikes Within 60 Miles: Portland". 60 hikes within 100 miles of downtown Portland, OR. Users can search the API for hikes using various endpoints(see below documentation)._

## Setup/Installation Instructions
* Download, install, and configure MySQL
* Open the terminal on your desktop
* Once in the terminal, use it to navigate to your desktop folder
* Once inside your desktop folder, use the command `git clone https://github.com/kpundt93/HikingTrail.Solution.git`
* After cloning the project, navigate into it using the command `cd HikingTrail.Solution/HikingTrail`
* Create a file named "appsettings.json" in the `HikingTrail` directory
* Add the following code to appsettings.json and add your MySQL user ID and password:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=hiking_trails;uid=[YOUR MYSQL USER ID];pwd=[YOUR MYSQL PASSWORD];"
  }
}
```
* Then run the command `dotnet ef database update`
* After creating the database, you'll need to populate it with the data in the .csv file.
* Go to MySQL Workbench and navigate to the table `hiking_trails`. Click on the arrow on the left to open the schema details. 
* Right click on `trails` table and select "Table Data Import Wizard"
* Navigate to where you cloned the project and select the file `trails.csv`
* Click next through the following windows to import the data
* If you need help, see this article: https://towardsdatascience.com/how-to-import-a-csv-file-into-mysql-workbench-17cb120169c8 
* After importing the data, return to your terminal
* Then run the command `dotnet restore` to install project dependencies
* Then run the command `dotnet run` to start the server

## API endpoints
#### HTTP Requests
```
GET /api/Trails
POST /api/Trails
GET /api/Trails{id}
DELETE /api/Trails{id}
```

#### Path Parameters
| Parameter | Type | Description |
| :---: | :---: | --- |
| Name | string | Returns any trail by name |
| Difficulty | string | Returns any trail by difficulty level |
| Length | double | Returns any trail by length |
| Family Friendly | string | Returns any trail by family friendly status |
| Distance from PDX | double | Returns any trail by distance from PDX |
| Configuration | string | Returns any trail by trail configuration |
| Season | string | Returns any trail by seasons that it is accessible |

#### Example Query
```
http://localhost:5000/api/trails/?difficulty=easy&familyFriendly=yes&configuration=loop
```

#### Sample JSON
```
{
  "trailId": 43,
  "name": "Trillium Lake ",
  "length": 1.9,
  "configuration": "Loop",
  "elevationGain": 10,
  "difficulty": "Easy",
  "familyFriendly": "Yes",
  "distanceFromPdx": 60.5,
  "latitude": 45.2672,
  "longitude": -121.7389,
  "season": "Summer - Fall"
}
```

#### Swagger Instructions
This API uses [Swagger](https://swagger.io/tools/swagger-ui/) REST API Documentation

* Navigate to http://localhost:5000/index.html to access Swagger and view API endpoints
* Note: the server must be running to access Swagger and test out parameters

## Known Bugs
* No known bugs

## License
_MIT License: https://opensource.org/licenses/MIT_

Copyright (c) _2022_ _Katie Pundt, Liz Thomas, and Kim Brannian_