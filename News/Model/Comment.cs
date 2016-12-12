using System;

namespace Model
{
    public class Comment
    {
        public int ID { get; set; }

        public int NewsDatailId { get; set; }

        public string CommentedContent { get; set; }

        public string Commentator { get; set; }

        public string UserIP { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
