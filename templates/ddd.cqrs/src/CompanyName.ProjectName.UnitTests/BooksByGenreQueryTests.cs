// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;

using CompanyName.ProjectName.DataAccess;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Domain.Books.Queries;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CompanyName.ProjectName.UnitTests
{
    [TestFixture]
    public class BooksByGenreQueryTests
    {
        private AppUnitOfWork _uow;

        [OneTimeSetUp]
        public void Setup()
        {
            var dbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

            AppDbContextInitializer.Initialize(dbContext);

            _uow = new AppUnitOfWork(dbContext);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _uow.Dispose();
        }

        [Test]
        public void TestBooksByProgrammingGenreQuery()
        {
            var programmingBooks = new BooksByGenreQuery(_uow)
                .Execute(BookGenre.Programming);

            Assert.AreEqual(3, programmingBooks.Count());
        }

        [Test]
        public void TestBooksByHistoryGenreQuery()
        {
            var historyBooks = new BooksByGenreQuery(_uow)
                .Execute(BookGenre.History);

            Assert.False(historyBooks.Any());
        }
    }
}