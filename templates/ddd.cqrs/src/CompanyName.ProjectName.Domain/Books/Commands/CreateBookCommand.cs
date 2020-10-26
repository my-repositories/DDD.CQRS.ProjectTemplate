// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;
using CompanyName.ProjectName.Domain.Books.Entities;
using DDD.CQRS.Abstract;

namespace CompanyName.ProjectName.Domain.Books.Commands
{
    public class CreateBookCommand : ICommand
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
    }
}