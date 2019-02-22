using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class StudentDAO
    {
        CentManagermentEntities db = null;

        // use using to open and close connection

        public bool Insert(Student student)
        {
            using (db = new CentManagermentEntities())
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }

        }


        // use using to open and close connection

        public bool Update(Student student)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    var studentUpdate = db.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
                    studentUpdate.StudentPhone = student.StudentPhone;
                    studentUpdate.StudentEmail = student.StudentEmail;
                    studentUpdate.StudentMark = student.StudentMark;
                    studentUpdate.StudentSchoolFee = student.StudentSchoolFee;
                    studentUpdate.StudentMark = student.StudentMark;
                    studentUpdate.StudentName = student.StudentName;
                    studentUpdate.StudentAdress = student.StudentAdress;
                    studentUpdate.StudentSchoolFeeStatus = student.StudentSchoolFeeStatus;
                    studentUpdate.StudentSchoolFeeDate = student.StudentSchoolFeeDate;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }

        }
        // use using to open and close connection

        public bool Delete(Student student)
        {
            using (db = new CentManagermentEntities())
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return true;
            }

        }


        public bool DeleteById(int idStudent)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    var student = db.Students.Find(idStudent);
                    db.Students.Remove(student);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

    }
}