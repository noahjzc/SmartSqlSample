using SmartSqlSampleChapterThree.Entity;

namespace SmartSqlSampleChapterThree.DomainService
{
    public interface IUserDomainService
    {
        User Register(string loginName, string password, string nickname);
    }
}