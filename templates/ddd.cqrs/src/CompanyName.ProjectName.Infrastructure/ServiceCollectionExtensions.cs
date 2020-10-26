// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;

using CompanyName.ProjectName.DataAccess;
using CompanyName.ProjectName.Domain;
using CompanyName.ProjectName.Domain.Authors.Queries;
using CompanyName.ProjectName.Domain.Books.Commands;
using CompanyName.ProjectName.Domain.Books.Handlers;
using CompanyName.ProjectName.Domain.Books.Queries;
using DDD.CQRS.Abstract;
using DDD.CQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.ProjectName.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.RegisterCommands()
                .RegisterQueries()
                .RegisterOther();
        }

        public static IServiceCollection RegisterConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile(Path.GetFullPath(Path.Combine(@"../../tools/appsettings.json")), true, true)
                .Build();

            return services.AddSingleton(sp => configuration);
        }

        private static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            return services
                .AddTransient<ICommandHandler<CreateBookCommand>, CreateBookCommandHandler>()
                .AddTransient<ICommandHandler<DeleteBookCommand>, DeleteBookCommandHandler>();
        }

        private static IServiceCollection RegisterOther(this IServiceCollection services)
        {
            return services
                .AddTransient<IAppUnitOfWork, AppUnitOfWork>()
                .AddTransient(sp => new CommandFactory(sp.GetRequiredService) as ICommandFactory)
                .AddTransient(sp => new QueryFactory(sp.GetRequiredService) as IQueryFactory)
                .AddTransient(sp =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();

                    return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                        .UseNpgsql(configuration.GetConnectionString("AppDbContext"))
                        .Options);
                });
        }

        private static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            return services
                .AddTransient<AuthorByIdQuery>()
                .AddTransient<BooksByGenreQuery>()
                .AddTransient<BookByIdQuery>();
        }
    }
}