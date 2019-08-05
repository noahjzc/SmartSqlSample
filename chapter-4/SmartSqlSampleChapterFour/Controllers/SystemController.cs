using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using SmartSqlSampleChapterFour.CommonRepository.Common;
using SmartSqlSampleChapterFour.Entity;

namespace SmartSqlSampleChapterFour.Controllers
{
    [Route("[controller]/[action]")]
    public class SystemController : Controller
    {
        private readonly ICommonDictionaryRepository _commonDictionaryRepository;
        private readonly ISqlMapper _sqlMapper;

        public SystemController(IServiceProvider serviceProvider
                                , ICommonDictionaryRepository commonDictionaryRepository)
        {
            _commonDictionaryRepository = commonDictionaryRepository;
            _sqlMapper = serviceProvider.GetSmartSql("Common").SqlMapper;
        }

        [HttpGet]
        public CommonDictionary Get([FromQuery(Name = "key")] string key)
        {
            return _commonDictionaryRepository.Get(key);
        }

        [HttpPut]
        public long Add([FromBody] CommonDictionary dictionary)
        {
            dictionary.CreateTime = DateTime.Now;
            return _commonDictionaryRepository.Add(dictionary);
        }

        [HttpPost]
        public long Set([FromBody] CommonDictionary dictionary)
        {
            var currentDictionary = _sqlMapper.QuerySingle<CommonDictionary>(new RequestContext
            {
                SqlId = "Get",
                Scope = "CommonDictionary",
                Request = new
                {
                    dictionary.Key
                }
            });

            if (currentDictionary == null)
            {
                dictionary.CreateTime = DateTime.Now;
                return _commonDictionaryRepository.Add(dictionary);
            }

            return _sqlMapper.Execute(new RequestContext
            {
                SqlId = "Set",
                Scope = "CommonDictionary",
                Request = new
                {
                    dictionary.Key,
                    dictionary.Value
                }
            });
        }
    }
}