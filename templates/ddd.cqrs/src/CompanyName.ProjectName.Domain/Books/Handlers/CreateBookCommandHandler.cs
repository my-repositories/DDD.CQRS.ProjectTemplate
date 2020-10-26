// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CompanyName.ProjectName.Domain.Books.Commands;
using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.Domain.Books.Handlers
{
    public class CreateBookCommandHandler
        : CommandHandler<CreateBookCommand>
    {
        public CreateBookCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override void Execute(CreateBookCommand command)
        {
            var book = new Book
            {
                Description = command.Description,
                Genre = command.Genre,
                Title = command.Title,
            };

            Uow.BookRepository.Add(book);
            Uow.SaveChanges();
        }
    }
}