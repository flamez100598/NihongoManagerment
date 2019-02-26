using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class TeacherDAO
    {
        CentManagermentEntities db = null;

        // use using to open and close connection

        public bool Insert(Teacher Teacher)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    db.Teachers.Add(Teacher);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                } 
            }

        }
        // use using to open and close connection

        public bool Update(Teacher teacher)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    var teacherUpdate = db.Teachers.FirstOrDefault(x => x.TeacherId == teacher.TeacherId);
                    teacherUpdate.TeacherName = teacher.TeacherName;
                    teacherUpdate.Age = teacher.Age;
                    teacherUpdate.PhoneNumber = teacher.PhoneNumber;
                    teacherUpdate.Address = teacher.Address;
                    teacherUpdate.Email = teacher.Email;
                    teacherUpdate.TimeToWork = teacher.TimeToWork;
                    teacherUpdate.PricePerHour = teacher.PricePerHour;
                    teacherUpdate.LevelEducation = teacher.LevelEducation;
                    teacherUpdate.Status = teacher.Status;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        // use using to open and close connection

        public bool Delete(Teacher teacher)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }



    }
}
