using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using SmartSqlSampleChapterFour.CommonRepository.User;
using SmartSqlSampleChapterFour.Entity;

namespace SmartSqlSampleChapterFour.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISqlMapper _sqlMapper;

        public UserController(IServiceProvider serviceProvider
                              , IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _sqlMapper = serviceProvider.GetSmartSql("User").SqlMapper;
        }

        [HttpPost]
        public UserEntity Register(string loginName, string password)
        {
            var user = new UserEntity
            {
                LoginName = loginName,
                Password = password,
                Status = 1,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            _userRepository.Insert(user);
            return user;
        }

        [HttpPost]
        public UserEntity Login(string loginName, string password)
        {
            return _sqlMapper.QuerySingle<UserEntity>(new RequestContext
            {
                SqlId = "GetEntity",
                Scope = "User",
                Request = new
                {
                    LoginName = loginName,
                    Password = password
                }
            });
        }
    }
}