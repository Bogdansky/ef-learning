using EfLearning.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfLearning.DataAccess
{
    public class LeanTrainingContextFactory : IDbContextFactory<LeanTrainingContext>
    {
        private readonly string _connectionString;

        public LeanTrainingContextFactory() 
        {
            _connectionString = Configuration.GetConnectionString("LeanTraining");
        }

        public LeanTrainingContext CreateDbContext()
        {
            Guard.NotNull(_connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<LeanTrainingContext>().UseNpgsql(_connectionString);

            return new LeanTrainingContext(optionsBuilder.Options);
        }
    }
}
