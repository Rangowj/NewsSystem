using System;

namespace Model
{
    public class News_Datail
    {
        public int ID { get; set; }
        public int NewsSortId { get; set; }
        public string NewsTitle { get; set; }
        public DateTime CreatedTime { get; set; }
        public string NewsContent { get; set; }
        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastCreatedTime { get; set; }
     }
}
