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
    public class CourseManager
    {
        public readonly ConvertDataCourse convertData = new ConvertDataCourse();
        CentManagermentEntities db = null;
        /// <summary>
        /// Thêm khóa học
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool CourseManagerInsert(CourseDTO course)
        {
            try
            {
                return new CourseDAO().Insert(convertData.ConvertDataCourseToEF(course));
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Sửa khóa học
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool CourseManagerUpdate(CourseDTO course)
        {
            try
            {
                return new CourseDAO().Update(convertData.ConvertDataCourseToEF(course));
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// xóa khóa học
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool CourseManagerDelete(int courseId)
        {
            try
            {
                return new CourseDAO().Delete(courseId);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<CourseDTO> GetListCourse()
        {
            List<CourseDTO> listCourseDTO = new List<CourseDTO>();
            List<Course> listCourse = new List<Course>();
            using (var db = new CentManagermentEntities())
            {
                listCourse = db.Courses.ToList();

            }
            foreach (var mb in listCourse)
            {
                listCourseDTO.Add(convertData.ConvertDataCourseToDTO(mb));
            }
            return listCourseDTO;
        }
        /// <summary>
        /// get all list course search and paging
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CourseDTO> GetListCourseSearchAndPaging(string searchString, int page, int pageSize)
        {
            List<CourseDTO> listDto = new List<CourseDTO>();
            List<Course> listCourse = new List<Course>();
            using (db = new CentManagermentEntities())
            {
                listCourse = db.Courses.ToList();
                if(!String.IsNullOrEmpty(searchString))
                {
                    listCourse = db.Courses.Where(x => x.CourseName.Contains(searchString)
                    //x.CourseTime.Contains(searchString) ||
                    /*x.CousePrice.ToString().Contains(searchString)*/).ToList();
                }
                foreach (var item in listCourse)
                {
                    listDto.Add(convertData.ConvertDataCourseToDTO(item));
                }
            }
            return listDto.ToPagedList(page, pageSize);
        }
        /// <summary>
        /// lay ra khoa hoc theo id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public CourseDTO GetCourseById(int courseId)
        {
            using (db = new CentManagermentEntities())
            {
                return convertData.ConvertDataCourseToDTO(db.Courses.SingleOrDefault(x => x.CourseId == courseId));
            }
        }

    }
}
