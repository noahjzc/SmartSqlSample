using SmartSql.DyRepository;
using SmartSqlSampleChapterFour.Entity;

namespace SmartSqlSampleChapterFour.CommonRepository.User
{
    public interface IUserRepository : IRepository<UserEntity, long>
    {
    }
}