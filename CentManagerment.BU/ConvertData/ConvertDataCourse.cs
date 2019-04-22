using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataCourse
    {
        public CourseDTO ConvertDataCourseToDTO(Course course)
        {
            var courseDTO = new CourseDTO()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Price = course.Price,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IsActive = course.IsActive,
                TotalPeriod = course.TotalPeriod   
            };
            return courseDTO;
        }
        public Course ConvertDataCourseToEF(CourseDTO courseDTO)
        {
            var courseEF = new Course()
            {
                CourseName = courseDTO.CourseName,
                Price = courseDTO.Price,
                StartDate = courseDTO.StartDate,
                EndDate = courseDTO.EndDate,
                IsActive = courseDTO.IsActive,
                TotalPeriod = courseDTO.TotalPeriod
            };
            if (courseDTO.CourseId > 0)
            {
                courseEF.CourseId = courseDTO.CourseId;
            }
            return courseEF;
        }
    }
}
