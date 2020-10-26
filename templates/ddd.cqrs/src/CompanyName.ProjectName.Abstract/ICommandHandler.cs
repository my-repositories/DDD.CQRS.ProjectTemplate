// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace CompanyName.ProjectName.Abstract
{
    public interface ICommandHandler<in TCommand> : IDisposable
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}