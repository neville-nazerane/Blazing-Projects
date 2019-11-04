# Blazing-Projects
Blazor based web app for managing projects


## Running locally: 

Run the following in src folder to setup database: 

    dotnet user-secrets set connectionStrings:sqlDb "<sql server string here>" -p .\BlazingProjects.Website\
    dotnet ef database update -p .\BlazingProjects.DataAccess\ -s .\BlazingProjects.Website\
