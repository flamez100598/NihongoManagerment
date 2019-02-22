using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataClass
    {
        public ClassDTO ConvertDataClassToDTO(Class cl)
        {
            var classDTO = new ClassDTO()
            {
                ClassId = cl.ClassId,
                ClassName = cl.ClassName,
                ClassCourseId = cl.ClassCourseId,
                ClassAmountStudent= cl.ClassAmountStudent,
                CourseDTO = new ConvertDataCourse().ConvertDataCourseToDTO(cl.Course)
            };
            return classDTO;
        }
        public Class ConvertDataClassToEF(ClassDTO classDTO)
        {
            var classEF = new Class()
            {
                ClassName = classDTO.ClassName,
                ClassAmountStudent = classDTO.ClassAmountStudent,
                ClassCourseId = classDTO.ClassCourseId
            };
            if (classDTO.ClassId > 0)
            {
                classEF.ClassId = classDTO.ClassId;
            }
            return classEF;
        }
    }
}
