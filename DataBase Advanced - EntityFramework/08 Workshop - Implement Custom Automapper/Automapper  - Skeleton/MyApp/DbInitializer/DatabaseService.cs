using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.DbInitializer.Contracts;

namespace MyApp.DbInitializer
{
    public class DatabaseService : IDatabaseService
    {
        private readonly MyCompanyContext dbContext;

        public DatabaseService(MyCompanyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InitializeDatabase()
        {
            this.dbContext.Database.Migrate();
        }
    }
}
