using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected HiddenBattleshipEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;

        // represent the database configuration
        protected DbContextOptions<HiddenBattleshipEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<HiddenBattleshipEntities>()
                .UseSqlServer(_configuration.GetConnectionString("HiddenBattleshipConnection"))
                .Options;

            dc = new HiddenBattleshipEntities(options);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }

    }
}
