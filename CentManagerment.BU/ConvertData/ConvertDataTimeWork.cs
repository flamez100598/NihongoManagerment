using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataTimeWork
    {
        public TimeWorkDTO ConvertDataTimeWorkToDTO(TimeWork cl)
        {
            var TimeWorkDTO = new TimeWorkDTO()
            {
                Id = cl.Id,
                Date = cl.Date,
                Hours = cl.Hours,
                TeacherId = cl.Teacher.TeacherId,
                TeacherName = cl.Teacher.TeacherName,
                DateStr = ((DateTime)cl.Date).ToString("yyyy-MM-dd")
            };
            return TimeWorkDTO;
        }
        public TimeWork ConvertDataTimeWorkToEF(TimeWorkDTO TimeWorkDTO)
        {
            var TimeWorkEF = new TimeWork()
            {
                Id = TimeWorkDTO.Id,
                Date = TimeWorkDTO.Date,
                Hours = TimeWorkDTO.Hours
            };
            if (TimeWorkDTO.Id > 0)
            {
                TimeWorkEF.Id = TimeWorkDTO.Id;
            }
            return TimeWorkEF;
        }
    }
}
