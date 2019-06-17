using System;

namespace SmartSqlSampleChapterThree.Entity
{
    public class User
    {
        public long Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}