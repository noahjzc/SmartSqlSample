using Microsoft.AspNetCore.Mvc;
using SmartSqlSampleChapterOne.DataAccess;
using SmartSqlSampleChapterOne.Entity;
using System.Collections.Generic;

namespace SmartSqlSampleChapterOne.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]/[action]")]
    public class ArticleController : Controller
    {
        private readonly ArticleDataAccess _articleDataAccess;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="articleDataAccess"></param>
        public ArticleController(ArticleDataAccess articleDataAccess)
        {
            _articleDataAccess = articleDataAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public T_Article Add([FromBody] T_Article article)
        {
            article.Id = _articleDataAccess.Insert(article);
            return article;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public T_Article Get([FromQuery] long id)
        {
            return _articleDataAccess.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update([FromBody] T_Article article)
        {
            return _articleDataAccess.Update(article) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateStatus([FromQuery] long id, [FromQuery] int status)
        {
            return _articleDataAccess.DyUpdate(new
            {
                Id = id,
                Status = status
            }) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public bool IsExist([FromQuery] long id)
        {
            return _articleDataAccess.IsExist(new
            {
                Id = id
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<T_Article> Query([FromQuery] string key = "")
        {
            return _articleDataAccess.Query(new
            {
                Title = key
            });
        }
    }
}