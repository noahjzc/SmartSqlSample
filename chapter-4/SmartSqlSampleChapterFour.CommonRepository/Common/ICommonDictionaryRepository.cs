using SmartSql.DyRepository;
using SmartSql.DyRepository.Annotations;
using SmartSqlSampleChapterFour.Entity;

namespace SmartSqlSampleChapterFour.CommonRepository.Common
{
    public interface ICommonDictionaryRepository
    {
        [Statement(Id = "Insert", Execute = ExecuteBehavior.QuerySingle)]
        long Add(CommonDictionary entity);

        CommonDictionary Get([Param("Key")] string key);

        int Set([Param("Key")] string key, [Param("Value")] string value);
    }
}