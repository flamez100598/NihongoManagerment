using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataTeacher
    {
        /// <summary>
        /// chuyển đổi dữ liệu bảng giáo viên từ EF sang DTO
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public TeacherDTO ConvertDataTeacherToDTO(Teacher cl)
        {
            // Xử lý gán dữ liệu
            var TeacherDTO = new TeacherDTO()
            {
                Age = cl.Age,
                Address = cl.Address,
                Email = cl.Email,
                PhoneNumber = cl.PhoneNumber,
                LevelEducation = cl.LevelEducation,
                PricePerHour = cl.PricePerHour,
                TeacherName = cl.TeacherName,
                TeacherId = cl.TeacherId,
                Status = cl.Status,
                TimeToWork = 0
            };
            int monthNow = DateTime.Now.Month;
            var listTimeWork = new TimeWorkManager().GetAllByMonth(monthNow,cl.TeacherId);
            if(listTimeWork != null && listTimeWork.Count > 0)
            {
                foreach(var item in listTimeWork)
                {
                    TeacherDTO.TimeToWork += item.Hours;
                }
            }
            // Chuyển trạng thái về text
            switch (TeacherDTO.Status)
            {
                case 1: TeacherDTO.StatusName = "Hoạt động"; break;
                case 2: TeacherDTO.StatusName = "Kết thúc"; break;
                default: TeacherDTO.StatusName = "Kết thúc"; break;
            }
            // Tính tổng giá tiền
            if(TeacherDTO.PricePerHour != null && TeacherDTO.TimeToWork != null)
            {
                TeacherDTO.Total = TeacherDTO.PricePerHour * TeacherDTO.TimeToWork;
            }
            return TeacherDTO;
        }

        /// <summary>
        /// Chuyển đổi dữ liệu bảng giao viên từ DTO sang EF
        /// </summary>
        /// <param name="TeacherDTO"></param>
        /// <returns></returns>
        public Teacher ConvertDataTeacherToEF(TeacherDTO TeacherDTO)
        {
            var TeacherEF = new Teacher()
            {
                Age = TeacherDTO.Age,
                Address = TeacherDTO.Address,
                Email = TeacherDTO.Email,
                PhoneNumber = TeacherDTO.PhoneNumber,
                LevelEducation = TeacherDTO.LevelEducation,
                PricePerHour = TeacherDTO.PricePerHour,
                TeacherName = TeacherDTO.TeacherName,
                Status = TeacherDTO.Status
            };
            if (TeacherDTO.TeacherId > 0)
            {
                TeacherEF.TeacherId = TeacherDTO.TeacherId;
            }
            return TeacherEF;
        }
    }
}
