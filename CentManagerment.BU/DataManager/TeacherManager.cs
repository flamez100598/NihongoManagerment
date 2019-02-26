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
    public class TeacherManager
    {
        CentManagermentEntities db = null;

        /// <summary>
        /// Thêm mới giáo viên
        /// </summary>
        /// <param name="Teacher">Giáo viên</param>
        /// <returns>Thành công hoặc thất bại</returns>
        public bool TeacherManagerInsert(TeacherDTO Teacher)
        {
            var teacher = new ConvertDataTeacher().ConvertDataTeacherToEF(Teacher);
            return new TeacherDAO().Insert(teacher);
        }

        /// <summary>
        /// Sửa giáo viên
        /// </summary>
        /// <param name="Teacher">Giáo viên</param>
        /// <returns>Thành công hoặc thất bại</returns>
        public bool TeacherManagerUpdate(TeacherDTO Teacher)
        {
            var teacher = new ConvertDataTeacher().ConvertDataTeacherToEF(Teacher);
            return new TeacherDAO().Update(teacher);
        }

        /// <summary>
        /// Xóa giáo viên
        /// </summary>
        /// <param name="Teacher">Giáo viên</param>
        /// <returns>Thành công hoặc thất bại</returns>
        public bool TeacherManagerDelete(TeacherDTO Teacher)
        {
            var teacher = new ConvertDataTeacher().ConvertDataTeacherToEF(Teacher);
            return new TeacherDAO().Delete(teacher);
        }

        /// <summary>
        /// Lấy danh sách giáo viên
        /// </summary>
        /// <returns>Danh sách giáo viên</returns>
        public List<TeacherDTO> GetListTeacher()
        {
            var listTeacher = new List<Teacher>();
            var listTeacherDTO = new List<TeacherDTO>();
            using (db = new CentManagermentEntities())
            {
                listTeacher = db.Teachers.ToList();
            }
            foreach (var tc in listTeacher)
            {
                var teacherDTO = new ConvertDataTeacher().ConvertDataTeacherToDTO(tc);
                if (teacherDTO != null)
                {
                    listTeacherDTO.Add(teacherDTO);
                }
            }
            return listTeacherDTO;
        }
        public TeacherDTO GetTeacherById(int teacherId)
        {
            using (var db = new CentManagermentEntities())
            {
                return new ConvertDataTeacher().ConvertDataTeacherToDTO(db.Teachers.Find(teacherId));
            }
        }

        public List<TimekeepingDTO> GetListTimekeepingByIdTeacher(int teacherId)
        {
            db = new CentManagermentEntities();
            var getListTimes = db.Timekeepings.Where(x=>x.TeacherID == teacherId);
            var listDTO = new List<TimekeepingDTO>();
            foreach (var time in getListTimes)
            {
                listDTO.Add(new ConvertDataTimekeeping().ConvertDataTimekeepingToDTO(time));
            }
            return listDTO;
        }
    }
}
