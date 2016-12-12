using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNewsModel
{
    public class VComment
    {
        public int ID { get; set; }

        public int NewsDatailId { get; set; }

        public string CommentedContent { get; set; }

        public string Commentator { get; set; }

        public string UserIP { get; set; }

        public string CreatedTime { get; set; }
    }
}
