using SmartSql.DyRepository;
using SmartSqlSampleChapterTwo.Entity;

namespace SmartSqlSampleChapterTwo.Repository
{
    public interface IArticleRepository : IRepository<T_Article, long>
    {
    }
}
