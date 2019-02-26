using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataTimekeeping
    {
        public TimekeepingDTO ConvertDataTimekeepingToDTO(Timekeeping cl)
        {
            var TimekeepingDTO = new TimekeepingDTO()
            {
                ID = cl.ID,
                TeacherID = cl.TeacherID,
                TimeIn = cl.TimeIn,
                TimeOut = cl.TimeOut,
                Days = cl.TimeIn.Value.ToShortDateString(),
                Hours = (cl.TimeOut - cl.TimeIn).Value.TotalHours,
                TimeInStr = cl.TimeIn.Value.ToShortTimeString(),
                TimeOutStr = cl.TimeOut.Value.ToShortTimeString(),
                TeacherDTO = new ConvertDataTeacher().ConvertDataTeacherToDTO(cl.Teacher),
                //TimeHours = (cl.TimeOut - cl.TimeIn).Value.Hours + ":" + ((cl.TimeOut - cl.TimeIn).Value.Minutes.ToString().Length == 1 ? ("0"+(cl.TimeOut - cl.TimeIn).Value.Minutes) : (cl.TimeOut - cl.TimeIn).Value.Minutes))
            };
            var getMinutes = (cl.TimeOut - cl.TimeIn).Value.Minutes;
            if(getMinutes.ToString().Length == 0)
            {
                TimekeepingDTO.TimeHours = (cl.TimeOut - cl.TimeIn).Value.Hours + ":0" + (cl.TimeOut - cl.TimeIn).Value.Minutes;
            }
            else
            {
                TimekeepingDTO.TimeHours = (cl.TimeOut - cl.TimeIn).Value.Hours + ":" + (cl.TimeOut - cl.TimeIn).Value.Minutes;
            }
            return TimekeepingDTO;
        }
        public Timekeeping ConvertDataTimekeepingToEF(TimekeepingDTO TimekeepingDTO)
        {
            var TimekeepingEF = new Timekeeping()
            {
                TeacherID = TimekeepingDTO.TeacherID,
                TimeIn = TimekeepingDTO.TimeIn,
                TimeOut = TimekeepingDTO.TimeOut
            };
            if (TimekeepingDTO.ID > 0)
            {
                TimekeepingEF.ID = TimekeepingDTO.ID;
            }
            if (TimekeepingDTO.TeacherDTO != null)
            {
                TimekeepingEF.Teacher = new ConvertDataTeacher().ConvertDataTeacherToEF(TimekeepingDTO.TeacherDTO);
            }
            return TimekeepingEF;
        }
    }
}
