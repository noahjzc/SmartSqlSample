using Microsoft.AspNetCore.Mvc;
using SmartSqlSampleChapterThree.DomainService;
using SmartSqlSampleChapterThree.Entity;

namespace SmartSqlSampleChapterThree.Api.UseAOPWithAutofac.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserDomainService _userDomainService;

        public UserController(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        [HttpGet]
        public User Register([FromQuery] string loginName, [FromQuery] string password, [FromQuery] string nickname)
        {
            return _userDomainService.Register(loginName, password, nickname);
        }
    }
}