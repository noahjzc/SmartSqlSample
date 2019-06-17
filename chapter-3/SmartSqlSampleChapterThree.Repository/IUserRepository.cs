using SmartSql.DyRepository;
using SmartSqlSampleChapterThree.Entity;

namespace SmartSqlSampleChapterThree.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
    }
}