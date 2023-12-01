﻿using Microsoft.EntityFrameworkCore.Design;

namespace Ticketing.DataAccess;

/// <summary>
/// Implementation of the DbContext design-time factory for Ticketing Database migration via Entity Framework CLI.
/// More Info:
/// <see cref="https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory"/>
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        DatabaseSettings _settings = new()
        {
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Ticketing;Trusted_Connection=True;",
            Timeout = 30,
            RetryCount = 3,
            RetryDelay = 5
        };

        return new DataContext(_settings);
    }
}
