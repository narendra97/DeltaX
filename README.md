# DeltaX IMDB

Prerequisites:
- Any IDE
- .NET Core SDK 2.1.4
- MySQL >=5.5

=====================================
Development Environment
=====================================
MySQL:
- IMDB application require a MySQL database to store it's data. Make sure to update the file "appsettings.json" file, changing the connection string named "IMDB" to reference your MySQL server.
- No need to write any DB Script all are there in the code. You just have to run the application all the database and table will automatically
  will be created.  
IMDB application:
- On any terminal move to the "IMDB" folder (the folder containing the "IMDB.csproj" file) and execute these commands:

dotnet restore
dotnet build
dotnet ef database update
dotnet run

- The application will be listening on http://localhost:8000
- Now you can call the api using any tool, like Postman, Curl, etc (See "Some Curl command examples" section)
=====================================
Some Curl command examples
=====================================
curl -i -H "Content-Type: application/json" -X POST -d "{'Name':'Amitabh Bachhan', 'Sex':'Male', 'DOB': '2018-03-10', 'BIO':'Super star'}" http://localhost:8000/actors
curl -i -H "Content-Type: application/json" http://localhost:8000/actors/1

=====================================
Run Application
=====================================
Run the IMDB Application in Visual studio

goto view folder open movieList.html file

to get movie list press get Movie list button.

