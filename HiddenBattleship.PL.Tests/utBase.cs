using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace HiddenBattleship.PL.Tests
{
    [TestClass]
    public abstract class utBase
    {
        protected HiddenBattleshipEntities db;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _config;

        protected DbContextOptions<HiddenBattleshipEntities> _options;


        public utBase()
        {

        }


        [TestInitialize]
        public void TestInitialize()
        {
            db = new HiddenBattleshipEntities(_options);
            transaction = db.Database.BeginTransaction();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
        }

    }
}
