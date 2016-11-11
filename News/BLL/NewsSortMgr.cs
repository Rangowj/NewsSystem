using System;
using System.Collections.Generic;
using DAL;
using System.Data;
using Model;

namespace BLL
{
    public class NewsSortMgr
    {
        DalNewsSort dns = new DalNewsSort();
        public void Insert(NewsSort model)
        {
            dns.Insert(model);
        }

        public void Delete(NewsSort model)
        {
            dns.Delete(model);
        }

        public DataSet Select(NewsSort model)
        {
            return dns.Select(model);
        }     

        public List<NewsSort> Select()
        {
            var list = new List<NewsSort>();
            var ds = dns.Select();
            var dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                var model = new NewsSort();
                model.ID = Convert.ToInt32(dr["ID"]);
                model.NewsSortName = Convert.ToString(dr["NewsSortName"]);
                model.CreatedTime = Convert.ToDateTime(dr["CreatedTime"]);
                list.Add(model);
            }
            return list;
        }

        public void Update(NewsSort model)
        {
            dns.Update(model);
        }
    }
}
