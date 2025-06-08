# Azure SQL Database Demo


[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/download)
[![Azure SQL Database](https://img.shields.io/badge/Azure%20SQL-Database-blue.svg)](https://azure.microsoft.com/services/sql-database/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%209.0.5-green.svg)](https://docs.microsoft.com/en-us/ef/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.txt)

## What's This About?

This project demonstrates how to get started with **Azure SQL Database for free** and connect it to a .NET 9 application with automatic database seeding. Perfect for learning, development and small projects without worrying about costs!

## Why Azure SQL Database?

Think of Azure SQL Database as your personal database in the cloud that:
- **Scales automatically**: Handles more users without you doing anything
- **Stays updated**: Microsoft keeps it secure and up-to-date  
- **Costs nothing to start**: Free tier gives you 32GB of storage
- **Works anywhere**: Access your data from any device, anywhere
- **Backs up automatically**: Your data is safe even if something goes wrong

## Prerequisites

Make sure you have the following:
- [Azure Account](https://portal.azure.com/) (free tier available)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or Visual Studio Code
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Basic knowledge of Azure Portal
- Familiarity with .NET and Entity Framework

## Project Structure

```
AzureSqlDatabaseDemoSln/
├── AzureSqlDatabaseDemo/
│   ├── Data/
│   │   └── ArtistContext.cs          # Entity Framework DbContext
│   ├── Models/
│   │   └── Artist.cs                 # Artist entity model
│   ├── Migrations/                   # EF Core migrations
│   │   ├── 20250607180832_firstmigration.cs
│   │   ├── 20250607180832_firstmigration.Designer.cs
│   │   └── ArtistContextModelSnapshot.cs
│   ├── Program.cs                    # Main application with seeding logic
│   └── AzureSqlDatabaseDemo.csproj  # Project file with dependencies
├── LICENSE.txt                      # MIT License
└── AzureSqlDatabaseDemoSln.sln      # Visual Studio Solution file
```

## Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core** - Web application framework
- **Entity Framework Core 9.0.5** - ORM for database operations
- **Azure SQL Database** - Cloud-based SQL database

## Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.5" />
```

## Step-by-Step Setup Guide

### 1. Setting Up Your Free Azure SQL Database

Follow the official Microsoft documentation for detailed steps:
-  [Deploy for Free - Azure SQL Database](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql)

**Video Tutorial**: Watch this excellent walkthrough (7:40 - 12:40 for database setup):
-  [Azure SQL Database Setup Tutorial](https://www.youtube.com/watch?v=KZK1DJfjNDA&t=460s)

### 2. Creating the .NET 9 Application

Follow the official ASP.NET Core tutorial:
-  [Tutorial: Create a minimal API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)

### 3. Entity Framework Core Integration

**Official Documentation**:
-  [Microsoft SQL Server Database Provider - EF Core](https://learn.microsoft.com/en-us/ef/core/providers/sql-server/?tabs=dotnet-core-cli)
-  [Entity Framework Documentation Hub](https://learn.microsoft.com/en-us/ef/)

**Video Tutorial**: Learn Entity Framework basics (2:05 - 15:42):
-  [Entity Framework Core Tutorial](https://www.youtube.com/watch?v=ocMwNAt3-G0&t=125s)

## Key Implementation Details

### Database Configuration (Program.cs)

The application uses **UseAzureSql** (EF 9+ optimized method) for Azure SQL Database:

```csharp
builder.Services.AddDbContext<ArtistContext>(options => 
    options.UseAzureSql(builder.Configuration.GetConnectionString("AzureSqlConnectionString")));
```

### Automatic Database Seeding

The application includes automatic database migration and seeding with 20 sample artists:

```csharp
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ArtistContext>();
    context.Database.Migrate();

    if (!context.Artists.Any())
    {
        // Seeds 20 diverse artists from different countries and genres
        context.Artists.AddRange(/* ... sample data ... */);
        context.SaveChanges();
    }
}
```

### Artist Model

```csharp
public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Country { get; set; }
    public string Biography { get; set; }
}
```

### Sample Data

The application automatically seeds 20 artists including:
- **Lena Rivers** (Indie Folk, USA)
- **Mateo Alvarez** (Latin Pop, Argentina)
- **Sophie Dubois** (Chanson, France)
- **Akira Sato** (J-Pop, Japan)
- **Nia Okafor** (Afrobeat, Nigeria)
- And 15 more diverse artists from around the world!

##  Try it yourself
Assuming you have the database already setup ina azure.

### Clone the Repository
```bash
git clone https://github.com/lukepadiachy/AzureSqlDatabaseDemo.git
cd AzureSqlDatabaseDemo
```

### Configure Connection String
Update your [`appsettings.json`](AzureSqlDatabaseDemo/appsettings.json) with your Azure SQL Database connection string:
```json
{
  "ConnectionStrings": {
    "AzureSqlConnectionString": "Your_Azure_SQL_Connection_String_Here"
  }
}
```

### Build and Run
```bash
dotnet build
dotnet run
```

### Verify Database Setup
The application will automatically:
-  Run Entity Framework migrations
-  Create the Artists table
-  Seed 20 sample artists if the table is empty

##  Database Schema

The migration creates the following table structure:

```sql
CREATE TABLE [Artists] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Genre] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [Biography] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Artists] PRIMARY KEY ([Id])
);
```

##  Success Verification

After running the application, your Azure SQL Database should show:
-  Artists table created with proper schema
-  20 sample artists automatically seeded
-  Application running successfully
-  OpenAPI documentation accessible

##  Related Resources

This project is based on my detailed blog post: **[Get Started with Azure SQL Database for Free](https://lukepadiachy.github.io/posts/azure-sql-database/)**

### Additional Learning Resources
-  [EF Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
-  [Azure SQL Database Documentation](https://docs.microsoft.com/en-us/azure/azure-sql/database/)


## Contributing

Feel free to:
-  Report issues
-  Suggest improvements
-  Submit pull requests

##  License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

##  Connect With Me

Have questions or want to discuss this project? Feel free to reach out on [LinkedIn](https://linkedin.com/in/lukepadiachy)!

---

**Free stuff is cool stuff!** Especially when it lets you explore cloud technologies without breaking the bank. This project proves you don't need expensive infrastructure to learn and build amazing things in the cloud.
