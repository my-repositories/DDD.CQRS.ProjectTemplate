// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CompanyName.ProjectName.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile(Path.GetFullPath(Path.Combine(@"../../tools/appsettings.json")), true, true)
                    .Build();

            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(configuration.GetConnectionString("AppDbContext"))
                .Options);
        }
    }
}
