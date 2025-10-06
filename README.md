# filebrowser-api

A simple API for a browser-based file system.

# Tech Stack

-   .NET 8
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server Express LocalDB
-   AutoMapper

# How to deploy & run

1. Make sure **SQL Server Express LocalDB** is installed.

2. Run Migrations

```bash
dotnet ef database update
```

3. Start the API from Visual Studio (F5) or through the terminal:

```bash
dotnet run --project FileBrowser.Api
```
