using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.EF6.Migrations;

namespace EfCodeFirstPlutoQueries.SqlConfiguration
{
    public class SqLiteConfiguration : DbConfiguration
    {
        public SqLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite",
                (DbProviderServices) SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
            SetMigrationSqlGenerator("System.Data.SQLite", () => new SQLiteMigrationSqlGenerator());
        }
    }
}