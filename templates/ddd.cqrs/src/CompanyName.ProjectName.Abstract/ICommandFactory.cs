// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace CompanyName.ProjectName.Abstract
{
    public interface ICommandFactory
    {
        void Execute<T>(T command)
            where T : class, ICommand;
    }
}