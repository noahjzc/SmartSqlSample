using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSqlSampleChapterOne.Entity.Enums;

namespace SmartSqlSampleChapterOne.Entity
{
    public class T_Article
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public ArticleStatus Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
