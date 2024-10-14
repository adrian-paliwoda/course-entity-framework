using System;
using Core;
using Core.Repositories;
using RepositoryPatternPluto.Repositories;
using RepositoryPatternPluto.SqlConfiguration;

namespace RepositoryPatternPluto
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository Authors { get; private set; }
        public ICourseRepository Courses { get; private set; }
        
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext plutoContext)
        {
            _context = plutoContext;

            Authors = new AuthorRepository(_context);
            Courses = new CourseRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}