// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DDD.CQRS.Domain;

namespace CompanyName.ProjectName.Domain
{
    public abstract class Query : QueryBase<IAppUnitOfWork>
    {
        protected Query(IAppUnitOfWork uow)
            : base(uow)
        {
        }
    }
}