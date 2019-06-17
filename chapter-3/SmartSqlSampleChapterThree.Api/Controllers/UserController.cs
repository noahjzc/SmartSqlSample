using Microsoft.AspNetCore.Mvc;
using SmartSqlSampleChapterThree.DomainService;
using SmartSqlSampleChapterThree.Entity;

namespace SmartSqlSampleChapterThree.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly NormalUserDomainService _userDomainService;

        public UserController(NormalUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        [HttpPost]
        public User Register([FromQuery] string loginName, [FromQuery] string password, [FromQuery] string nickname)
        {
            return _userDomainService.Register(loginName, password, nickname);
        }
    }
}