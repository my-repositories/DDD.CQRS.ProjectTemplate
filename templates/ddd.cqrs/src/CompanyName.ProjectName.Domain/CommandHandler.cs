// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DDD.CQRS.Abstract;
using DDD.CQRS.Domain;

namespace CompanyName.ProjectName.Domain
{
    public abstract class CommandHandler<TCommand>
        : CommandHandlerBase<TCommand, IAppUnitOfWork>
        where TCommand : ICommand
    {
        protected CommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }
    }
}