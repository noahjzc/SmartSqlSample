using Microsoft.AspNetCore.Mvc;
using SmartSqlSampleChapterTwo.Entity;
using SmartSqlSampleChapterTwo.Repository;
using System.Collections.Generic;

namespace SmartSqlSampleChapterTwo.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]/[action]")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="articleRepository"></param>
        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public T_Article Add([FromBody] T_Article article)
        {
            article.Id = _articleRepository.Insert(article);
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
            return _articleRepository.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update([FromBody] T_Article article)
        {
            return _articleRepository.Update(article) > 0;
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
            return _articleRepository.DyUpdate(new
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
            return _articleRepository.IsExist(new
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
            return _articleRepository.Query(new
            {
                Title = key
            });
        }
    }
}