using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class TimeWorkManager
    {
        CentManagermentEntities db = null;
        TimeWorkDAO dao = new TimeWorkDAO();
        ConvertDataTimeWork convert = new ConvertDataTimeWork();
        //insert Time Work
        public bool Insert(TimeWorkDTO dto)
        {
            var teacher = convert.ConvertDataTimeWorkToEF(dto);
            return dao.Insert(teacher);
        }

        public List<TimeWorkDTO> GetAllByMonth(int month, int id)
        {
            using (var db = new CentManagermentEntities())
            {
                var list = db.TimeWorks.Where(x => x.TeacherId == id && x.Date.Value.Month == month).ToList();
                var listDTO = new List<TimeWorkDTO>();
                foreach (var item in list)
                {
                    listDTO.Add(new ConvertDataTimeWork().ConvertDataTimeWorkToDTO(item));
                }
                return listDTO;
            }
        }

        public List<TimeWorkDTO> GetAllByIdTeacher(int id)
        {
            using (var db = new CentManagermentEntities())
            {
                var list = db.TimeWorks.Where(x => x.TeacherId == id).ToList();
                var listDTO = new List<TimeWorkDTO>();
                foreach (var item in list)
                {
                    listDTO.Add(new ConvertDataTimeWork().ConvertDataTimeWorkToDTO(item));
                }
                return listDTO;
            }
        }

        public TimeWorkDTO GetTimeWork(int id)
        {
            using (var db = new CentManagermentEntities())
            {
                var timeWorkEF = db.TimeWorks.FirstOrDefault(x => x.Id == id);
                var timeWorkDTO = new ConvertDataTimeWork().ConvertDataTimeWorkToDTO(timeWorkEF);
                return timeWorkDTO;
            }
        }

        public bool Edit(double time, DateTime date, int id)
        {
            using(var db = new CentManagermentEntities())
            {
                try
                {
                    var e = db.TimeWorks.FirstOrDefault(x => x.Id == id);
                    e.Hours = time;
                    e.Date = date;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public bool Create(double time, DateTime date, int id)
        {
            TimeWork cl = new TimeWork()
            {
                Hours = time,
                Date = date,
                TeacherId = id
            };
            return new TimeWorkDAO().Insert(cl);
        }
        // delete time work
        public bool Delete(int id)
        {
            return new TimeWorkDAO().Delete(id);
        }
    }
}
