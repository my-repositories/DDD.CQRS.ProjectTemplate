// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CompanyName.ProjectName.Domain.Books.Commands;
using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.Cli
{
    public partial class Demo
    {
        public void ExecuteCreateBookCommand()
        {
            commandFactory.Execute(new CreateBookCommand
            {
                Description = "Some description for new Book",
                Genre = BookGenre.Memoir,
                Title = "Fifty Shades of C#",
            });
        }

        public void ExecuteDeleteBookCommand(int id)
        {
            commandFactory.Execute(new DeleteBookCommand(id));
        }
    }
}