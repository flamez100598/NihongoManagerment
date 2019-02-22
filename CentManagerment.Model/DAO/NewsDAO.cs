using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class NewsDAO
    {
        CentManagermentEntities db = null;
        // use using to open and close connection
        public bool Insert(News news)
        {
            using (db = new CentManagermentEntities())
            {
                db.News.Add(news);
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Update(News news)
        {
            using (db = new CentManagermentEntities())
            {
                var newsUpdate = db.News.FirstOrDefault(x => x.NewsId == news.NewsId);
                newsUpdate.NewsContent = news.NewsContent;
                newsUpdate.NewsShortContent = news.NewsShortContent;
                newsUpdate.NewsTitle = news.NewsTitle;
                newsUpdate.NewsAvatar = news.NewsAvatar;
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        //public bool Delete(News news)
        //{
        //    using (db = new CentManagermentEntities())
        //    {
        //        db.News.Remove(news);
        //        db.SaveChanges();
        //    }
        //    return true;

        //}
        public bool Delete(int idnew)
        {
            try
            {
                using (db = new CentManagermentEntities())
                {
                    var getNew = db.News.Find(idnew);
                    db.News.Remove(getNew);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
