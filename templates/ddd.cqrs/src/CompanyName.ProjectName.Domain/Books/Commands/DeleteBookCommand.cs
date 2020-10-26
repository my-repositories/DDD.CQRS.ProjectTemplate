// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DDD.CQRS.Abstract;

namespace CompanyName.ProjectName.Domain.Books.Commands
{
    public class DeleteBookCommand : ICommand
    {
        public DeleteBookCommand(int id)
        {
            BookId = id;
        }

        public int BookId { get; set; }
    }
}
