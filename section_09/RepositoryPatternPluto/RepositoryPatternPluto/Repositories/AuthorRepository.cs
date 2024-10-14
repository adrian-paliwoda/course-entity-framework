using System.Data.Entity;
using System.Linq;
using Core.Domain;
using Core.Repositories;
using RepositoryPatternPluto.SqlConfiguration;

namespace RepositoryPatternPluto.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public PlutoContext PlutoContext => Context as PlutoContext;
        
        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return PlutoContext.Authors
                               .Include(p => p.Courses)
                               .SingleOrDefault(p => p.Id == id);
        }
    }
}