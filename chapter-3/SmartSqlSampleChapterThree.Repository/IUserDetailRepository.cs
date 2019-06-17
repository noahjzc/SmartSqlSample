using SmartSql.DyRepository;
using SmartSqlSampleChapterThree.Entity;

namespace SmartSqlSampleChapterThree.Repository
{
    public interface IUserDetailRepository : IRepository<UserDetail, long>
    {
    }
}