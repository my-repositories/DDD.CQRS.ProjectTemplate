// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using CompanyName.ProjectName.DataAccess;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.ProjectName.Cli
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<Demo>();
            services.RegisterConfiguration().AddInfrastructure();

            var serviceProvider = services.BuildServiceProvider();

            using (var appDbContext = serviceProvider.GetRequiredService<AppDbContext>())
            {
                AppDbContextInitializer.Initialize(appDbContext);
            }

            serviceProvider.GetRequiredService<Demo>().Start();
        }

        private static void Start(this Demo demo)
        {
            // demo.ExecuteCreateBookCommand();
            // demo.ExecuteDeleteBookCommand(2);
            demo.ShowBookById(1);
            Console.WriteLine("#===================================#");
            Console.WriteLine();
            Console.WriteLine();

            demo.ShowBooksByGenre(BookGenre.Programming);
            Console.WriteLine("#===================================#");
            Console.WriteLine();
            Console.WriteLine();

            demo.ShowGetAllAuthorsWithBooks();
            Console.WriteLine("#===================================#");
            Console.WriteLine();
            Console.WriteLine();

            demo.ShowGetAllBooksWithAuthors();
        }
    }
}
