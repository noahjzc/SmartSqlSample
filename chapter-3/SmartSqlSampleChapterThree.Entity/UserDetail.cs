using System;

namespace SmartSqlSampleChapterThree.Entity
{
    public class UserDetail
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Nickname { get; set; }

        public string Avatar { get; set; }

        public bool? Sex { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}