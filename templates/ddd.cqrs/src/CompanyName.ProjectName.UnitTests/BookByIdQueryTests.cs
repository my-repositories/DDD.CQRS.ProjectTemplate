// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using CompanyName.ProjectName.DataAccess;
using CompanyName.ProjectName.Domain.Books.Queries;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CompanyName.ProjectName.UnitTests
{
    [TestFixture]
    public class BookByIdQueryTests
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
        public void TestBookBy5IdQuery()
        {
            var comicBook = new BookByIdQuery(_uow)
                .Execute(5);

            Assert.AreEqual("Batman and Robin", comicBook.Title);
        }

        [Test]
        public void TestBookByNotExistsIdQuery()
        {
            var book = new BookByIdQuery(_uow)
                .Execute(99999);

            Assert.IsNull(book);
        }
    }
}