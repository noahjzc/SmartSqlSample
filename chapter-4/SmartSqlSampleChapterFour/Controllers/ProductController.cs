using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using SmartSqlSampleChapterFour.Entity;
using SmartSqlSampleChapterFour.ProductRepository;

namespace SmartSqlSampleChapterFour.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISqlMapper _sqlMapper;

        public ProductController(IServiceProvider serviceProvider
                                 , IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _sqlMapper = serviceProvider.GetSmartSql("Product").SqlMapper;
        }

        // GET
        [HttpGet]
        public Product GetByRepository([FromQuery] long id)
        {
            return _productRepository.GetById(id);
        }

        // GET
        [HttpGet]
        public Product GetBySqlMap([FromQuery] long id)
        {
            return _sqlMapper.QuerySingle<Product>(new RequestContext
            {
                SqlId = "GetEntity",
                Scope = "Product",
                Request = new
                {
                    Id = id
                }
            });
        }

        [HttpPost]
        public long Create([FromBody] Product product)
        {
            return _productRepository.Insert(product);
        }

        [HttpGet]
        public IEnumerable<Product> Query()
        {
            return _productRepository.Query(new { });
        }
    }
}