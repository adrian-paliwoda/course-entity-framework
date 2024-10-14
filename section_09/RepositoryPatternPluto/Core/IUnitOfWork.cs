using System;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        ICourseRepository Courses { get; }

        int Complete();
    }
}