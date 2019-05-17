using SmartSql.DyRepository;
using SmartSql.DyRepository.Annotations;
using SmartSqlSampleChapterTwo.Entity;
using System.Data;

namespace SmartSqlSampleChapterTwo.Repository
{
    [SqlMap(Scope = "CustomScope")]
    public interface IArticleRepository : IRepository<T_Article, long>
    {
        [Statement(CommandType = CommandType.Text, Execute = ExecuteBehavior.ExecuteScalar, Id = "Offline")]
        int OfflineArticle([Param("Id", FieldType = typeof(long))] long articleId);

        [Statement(Sql = "Update T_Article Set Status = 1 Where Id = @Id")]
        int OnlineArticle([Param("Id")] long articleId);
    }
}
