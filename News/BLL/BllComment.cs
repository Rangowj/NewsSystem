using Model;
using DAL;
using System.Collections.Generic;
using System.Data;
using System;
using VNewsModel;

namespace BLL
{
    public class BllComment
    {
        public void InsertConmmentInfo(Comment model)
        {
            new DalComment().InsertCommentInfo(model);
        }

        public List<VComment> SelectCommentInfo(int pageSize, int pageIndex, int id)
        {
            var list = new List<VComment>();
            DataSet ds = new DalComment().SelectCommentInfo(pageSize,pageIndex,id);
            DataTable dt = new DataTable();
            if(ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            foreach(DataRow dr in dt.Rows)
            {
                VComment model = new VComment
                {
                    CommentedContent = Convert.ToString(dr["CommentedContent"]),
                    UserIP = Convert.ToString(dr["UserIP"]),
                    CreatedTime = Convert.ToString(dr["CreatedTime"])
                };
                list.Add(model);
            }
            return list;
        }

        public int SelectRowCount(int NewsDatailId)
        {
            return new DalComment().SelectRowCount(NewsDatailId);
        }
    }
}
