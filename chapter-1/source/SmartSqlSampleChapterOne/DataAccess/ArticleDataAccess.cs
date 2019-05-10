using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using SmartSqlSampleChapterOne.Entity;
using System;
using System.Collections.Generic;

namespace SmartSqlSampleChapterOne.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleDataAccess
    {
        private readonly ISqlMapper _sqlMapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        public ArticleDataAccess(IServiceProvider sp)
        {
            _sqlMapper = sp.GetSmartSql("SmartSqlSampleChapterOne").SqlMapper;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public long Insert(T_Article article)
        {
            return _sqlMapper.ExecuteScalar<long>(new RequestContext
            {
                Scope = "Article",
                SqlId = "Insert",
                Request = article
            });
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public int Update(T_Article article)
        {
            return _sqlMapper.Execute(new RequestContext
            {
                Scope = "Article",
                SqlId = "Update",
                Request = article
            });
        }

        /// <summary>
        /// DyUpdate
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public int DyUpdate(object updateObj)
        {
            return _sqlMapper.Execute(new RequestContext
            {
                Scope = "Article",
                SqlId = "Update",
                Request = updateObj
            });
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id)
        {
            return _sqlMapper.Execute(new RequestContext
            {
                Scope = "Article",
                SqlId = "Delete",
                Request = new { Id = id }
            });
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_Article GetById(long id)
        {
            return _sqlMapper.QuerySingle<T_Article>(new RequestContext
            {
                Scope = "Article",
                SqlId = "GetEntity",
                Request = new { Id = id }
            });
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public IEnumerable<T_Article> Query(object queryParams)
        {
            return _sqlMapper.Query<T_Article>(new RequestContext
            {
                Scope = "Article",
                SqlId = "Query",
                Request = queryParams
            });
        }

        /// <summary>
        /// GetRecord
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public int GetRecord(object queryParams)
        {
            return _sqlMapper.ExecuteScalar<int>(new RequestContext
            {
                Scope = "Article",
                SqlId = "GetRecord",
                Request = queryParams
            });
        }

        /// <summary>
        /// IsExist
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public bool IsExist(object queryParams)
        {
            return _sqlMapper.QuerySingle<bool>(new RequestContext
            {
                Scope = "Article",
                SqlId = "IsExist",
                Request = queryParams
            });
        }
    }
}
