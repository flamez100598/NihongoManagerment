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
    public class ClassManager
    {
        CentManagermentEntities db = null;

        /// <summary>
        /// Insert class
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        public bool ClassManagerInsert(ClassDTO Class)
        {
            try
            {
                return new ClassDAO().Insert(new ConvertDataClass().ConvertDataClassToEF(Class));
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Update class
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        public bool ClassManagerUpdate(ClassDTO Class)
        {
            try
            {
                return new ClassDAO().Update(new ConvertDataClass().ConvertDataClassToEF(Class));
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// delete class
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        public bool ClassManagerDelete(int id)
        {
            try
            {
                return new ClassDAO().Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Get List class DTO
        /// </summary>
        /// <returns></returns>
        /// #region Dungdz
        public IEnumerable<ClassDTO> GetListClass(string searchString, int page, int pageSize)
        {
            var listDTO = new List<ClassDTO>();
            List<Class> listClass = new List<Class>();
            using (db = new CentManagermentEntities())
            {
                listClass = db.Classes.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    listClass = db.Classes.Where(x => x.ClassName.Contains(searchString) ||
                    x.ClassAmountStudent.ToString().Contains(searchString)).ToList();
                }
                foreach (var mb in listClass)
                {
                    listDTO.Add(new ConvertDataClass().ConvertDataClassToDTO(mb));
                }
            }

            return listDTO.ToPagedList(page, pageSize);

        }

        public ClassDTO GetClassById(int classId)
        {
            using (db = new CentManagermentEntities())
            {
                return new ConvertDataClass().ConvertDataClassToDTO(db.Classes.Find(classId));
            }
        }
        /// <summary>
        /// get list class
        /// </summary>
        /// <returns></returns>
        public List<ClassDTO> GetListSelectClass()
        {
            using (var db = new CentManagermentEntities())
            {
                var listEF = db.Classes.ToList();
                var listDTO = new List<ClassDTO>();
                if (listEF != null)
                {
                    foreach (var item in listEF)
                    {
                        listDTO.Add(new ConvertDataClass().ConvertDataClassToDTO(item));
                    }
                }
                return listDTO;
            }
        }
    }
}