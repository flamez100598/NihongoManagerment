using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class CourseDAO
    {
        CentManagermentEntities db = null;
        // use using to open and close connection
        public bool Insert(Course course)
        {
            using (db = new CentManagermentEntities())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Update(Course course)
        {
            using (db = new CentManagermentEntities())
            {
                var courseUpdate = db.Courses.FirstOrDefault(x=>x.CourseId == course.CourseId);
                courseUpdate.CourseName = course.CourseName;
                courseUpdate.StartDate = course.StartDate;
                courseUpdate.EndDate = course.EndDate;
                courseUpdate.IsActive = course.IsActive;
                courseUpdate.Price = course.Price;
                db.SaveChanges();
            }
            return true;

        }
        // use using to open and close connection
        public bool Delete(int courseId)
        {
            using (db = new CentManagermentEntities())
            {
                db.Courses.Remove(db.Courses.Find(courseId));
                db.SaveChanges();
            }
            return true;


        }
    }
}
