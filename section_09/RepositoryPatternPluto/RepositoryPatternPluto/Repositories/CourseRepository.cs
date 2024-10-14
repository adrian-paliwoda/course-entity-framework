using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Domain;
using Core.Repositories;
using RepositoryPatternPluto.SqlConfiguration;

namespace RepositoryPatternPluto.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public PlutoContext PlutoContext => Context as PlutoContext;

        public CourseRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return PlutoContext.Courses
                               .OrderByDescending(p => p.FullPrice)
                               .Take(count)
                               .ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return PlutoContext.Courses
                               .Include(c => c.Author)
                               .OrderBy(c => c.Name)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();
        }
    }
}