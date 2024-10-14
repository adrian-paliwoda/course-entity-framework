using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDatabaseFirstHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new VidzyDbContext();
            db.AddVideo("Name", DateTime.Now, EfDatabaseFirstHomework.Model.Classiﬁcation.Gold, "Comedy");
        }
    }
}
