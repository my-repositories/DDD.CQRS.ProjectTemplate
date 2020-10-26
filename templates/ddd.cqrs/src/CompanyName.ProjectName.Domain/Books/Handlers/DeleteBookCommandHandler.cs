// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using CompanyName.ProjectName.Domain.Books.Commands;

namespace CompanyName.ProjectName.Domain.Books.Handlers
{
    public class DeleteBookCommandHandler
        : CommandHandler<DeleteBookCommand>
    {
        public DeleteBookCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override void Execute(DeleteBookCommand command)
        {
            var book = Uow.BookRepository.Get(command.BookId)
                ?? throw new ArgumentException("Deleted book not found!");

            Uow.BookRepository.Remove(book);
            Uow.SaveChanges();
        }
    }
}