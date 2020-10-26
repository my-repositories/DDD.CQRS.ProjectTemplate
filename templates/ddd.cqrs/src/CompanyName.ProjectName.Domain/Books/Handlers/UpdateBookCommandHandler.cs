// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using CompanyName.ProjectName.Domain.Books.Commands;

namespace CompanyName.ProjectName.Domain.Books.Handlers
{
    public class UpdateBookCommandHandler
        : CommandHandler<UpdateBookCommand>
    {
        public UpdateBookCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override void Execute(UpdateBookCommand command)
        {
            var book = Uow.BookRepository.Get(command.BookId)
                       ?? throw new ArgumentException("Updated book not found!");

            book.Description = command.Description;
            book.Genre = command.Genre;
            book.Title = command.Title;
            Uow.SaveChanges();
        }
    }
}