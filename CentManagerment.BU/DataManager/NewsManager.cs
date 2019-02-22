using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using CentManagerment.Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class NewsManager
    {
        CentManagermentEntities db = null;
        public readonly ConvertDataNews convertData = new ConvertDataNews();
        public NewsManager()
        {
            db = new CentManagermentEntities();
        }
        public bool NewsManagerInsert(NewsDTO newdto)
        {
            try
            {
                return new NewsDAO().Insert(new ConvertDataNews().ConvertDataNewsToEF(newdto));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool NewsManagerUpdate(NewsDTO newdto)
        {
            try
            {
                return new NewsDAO().Update(new ConvertDataNews().ConvertDataNewsToEF(newdto));
            }
            catch (Exception)
            {

                return false;
            }
        }
        //public bool NewsManagerDelete(NewsDTO course)
        //{
        //    try
        //    {
        //        return new NewsDAO().Delete(new ConvertDataNews().ConvertDataNewsToEF(course));
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        public bool NewsManagerDelete(int idnew)
        {
            try
            {
                return new NewsDAO().Delete(idnew);
            }
            catch (Exception)
            {

                return false;
            }
        }


        public List<NewsDTO> GetListNews()
        {
            List<NewsDTO> listNewsDTO = new List<NewsDTO>();
            List<News> listNews = new List<News>();
            using (var db = new CentManagermentEntities())
            {
                listNews = db.News.OrderBy(x=>x.NewsPostDate).ToList();

            }
            foreach (var n in listNews)
            {
                listNewsDTO.Add(convertData.ConvertDataNewsToDTO(n));
            }
            return listNewsDTO;
        }


        public NewsDTO getNewById(int id)
        {
            NewsDTO NewsDTO = new NewsDTO();
            News News = new News();
            using (var db = new CentManagermentEntities())
            {
                News = db.News.Find(id);

            }
            if (News != null)
                NewsDTO = convertData.ConvertDataNewsToDTO(News);
            else
                NewsDTO = null;
            return NewsDTO;
        }

        public IEnumerable<NewsDTO> GetListNews(string searchString, int page, int pageSize)
        {
            var listDTO = new List<NewsDTO>();
            List<News> listNews = new List<News>();
            using (db = new CentManagermentEntities())
            {
                listNews = db.News.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    listNews = db.News.Where(x => x.NewsContent.Contains(searchString) ||
                    x.NewsShortContent.Contains(searchString) || x.NewsTitle.Contains(searchString)).ToList();
                }
                foreach (var n in listNews)
                {
                    listDTO.Add(new ConvertDataNews().ConvertDataNewsToDTO(n));
                }
            }

            return listDTO.ToPagedList(page, pageSize);

        }
    }
}
