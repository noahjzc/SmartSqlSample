using System;

namespace SmartSqlSampleChapterFour.Entity
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
    }
}