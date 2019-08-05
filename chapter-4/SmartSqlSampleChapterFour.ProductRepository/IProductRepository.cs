using System;
using SmartSql.DyRepository;
using SmartSqlSampleChapterFour.Entity;

namespace SmartSqlSampleChapterFour.ProductRepository
{
    public interface IProductRepository : IRepository<Product, long>
    {
    }
}