using System;
using SmartSql.AOP;
using SmartSqlSampleChapterThree.Entity;
using SmartSqlSampleChapterThree.Repository;

namespace SmartSqlSampleChapterThree.DomainService
{
    public class UseAopUserDomainService : IUserDomainService
    {
        private const string DEFAULT_AVATAR = "https://smartsql.net/logo.png";

        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;

        public UseAopUserDomainService(IUserRepository userRepository, IUserDetailRepository userDetailRepository)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
        }

        [Transaction]
        public User Register(string loginName, string password, string nickname)
        {
            var user = new User
            {
                LoginName = loginName,
                Password = password,
                Status = 1,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };

            user.Id = _userRepository.Insert(user);

            _userDetailRepository.Insert(new UserDetail
            {
                UserId = user.Id,
                Nickname = nickname,
                Avatar = DEFAULT_AVATAR,
                Sex = null,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            });

            return user;
        }
    }
}