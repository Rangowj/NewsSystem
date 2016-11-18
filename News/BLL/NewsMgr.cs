using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NewsMgr
    {

        DalNews dn = new DalNews();       
        public void Insert(News_Datail model)
        {
           dn .Insert(model);
        }

        public void Delete(News_Datail model)
        {
            dn.Delete(model);
        }

        public List<News_Datail> Select()
        {
            var list = new List<News_Datail>();
            var ds = dn.Select();
            var dt = new DataTable();
            if(ds !=null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            } 
            foreach(DataRow dr in dt.Rows)
            {
                var mod = new News_Datail();
                mod.ID = Convert.ToInt32(dr["ID"]);
                mod.NewsSortId = Convert.ToInt32(dr["NewsSortId"]);
                mod.NewsTitle = Convert.ToString(dr["NewsTitle"]);
                mod.CreatedTime = Convert.ToDateTime(dr["CreatedTime"]);
                list.Add(mod);
            }
            return list;
        }

        public DataSet Select2()
        {
            return dn.Select();
        }

        public DataSet Select3(News_Datail model)
        {
            return dn.Select2(model);
        }

        public DataSet Select4(News_Datail model)
        {
            return dn.Select3(model);
        }

        public List<Public> Select5(Public model)
        {
            var list = new List<Public>();
            var ds = dn.Select4(model);
            var dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                var mod = new Public();
                mod.ID = Convert.ToInt32(dr["ID"]);
                mod.NewsSortId = Convert.ToInt32(dr["NewsSortId"]);
                mod.NewsTitle = Convert.ToString(dr["NewsTitle"]);
                mod.NewsSortName = Convert.ToString(dr["NewsSortName"]);
                mod.NewsContent = Convert.ToString(dr["NewsContent"]);
                list.Add(mod);
            }
            return list;
        }

        public DataSet Select6(News_Datail model)
        {
            DataSet ds = new DalNews().Select5(model);
            return ds;
        }

        public void Update(News_Datail model)
        {
            dn.Update(model);
        }
    }
}
