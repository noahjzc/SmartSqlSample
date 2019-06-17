using System;
using SmartSql.DbSession;
using SmartSqlSampleChapterThree.Entity;
using SmartSqlSampleChapterThree.Repository;

namespace SmartSqlSampleChapterThree.DomainService
{
    public class NormalUserDomainService : IUserDomainService
    {
        private const string DEFAULT_AVATAR = "https://smartsql.net/logo.png";

        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly ITransaction _transaction;

        public NormalUserDomainService(IUserRepository userRepository, IUserDetailRepository userDetailRepository, ITransaction transaction)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _transaction = transaction;
        }

        // use transaction on repository's sql mapper
        // public User Register(string loginName, string password, string nickname)
        // {
        //     try
        //     {
        //         _userRepository.SqlMapper.BeginTransaction();
        //
        //         var user = new User
        //         {
        //             LoginName = loginName,
        //             Password = password,
        //             Status = 1,
        //             CreateTime = DateTime.Now,
        //             ModifiedTime = DateTime.Now
        //         };
        //
        //         user.Id = _userRepository.Insert(user);
        //
        //         _userDetailRepository.Insert(new UserDetail
        //         {
        //             UserId = user.Id,
        //             Nickname = nickname,
        //             Avatar = DEFAULT_AVATAR,
        //             Sex = null,
        //             CreateTime = DateTime.Now,
        //             ModifiedTime = DateTime.Now
        //         });
        //
        //         _userRepository.SqlMapper.CommitTransaction();
        //         return user;
        //     }
        //     catch
        //     {
        //         _userRepository.SqlMapper.RollbackTransaction();
        //         throw;
        //     }
        // }
        
        public User Register(string loginName, string password, string nickname)
        {
            try
            {
                _transaction.BeginTransaction();
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

                _transaction.CommitTransaction();
                return user;
            }
            catch
            {
                _transaction.RollbackTransaction();
                throw;
            }
        }
    }
}