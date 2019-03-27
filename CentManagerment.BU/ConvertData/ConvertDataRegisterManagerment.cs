﻿using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataRegisterManagerment
    {
        public RegisterManagermentDTO ConvertDataRegisterToDTO(RegisterManagerment register)
        {
            var registerDTO = new RegisterManagermentDTO()
            {
                register_course = register.register_course,
                register_email = register.register_email,
                register_id = register.register_id,
                register_name = register.register_name,
                register_phone = register.register_phone,
                register_status = register.register_status,
                register_message = register.register_message
            };
            switch (register.register_status)
            {
                case (int)Common.Enum.StatusRegister.Confirmed:
                    registerDTO.register_statusname = "Đã xác nhận";
                    break;
                default:
                    registerDTO.register_statusname = "Chưa xác nhận";
                    break;
            }
            return registerDTO;
        }



        public RegisterManagerment ConvertDataRegisterToEF(RegisterManagermentDTO registerDTO)
        {
            var register = new RegisterManagerment()
            {
                register_course = registerDTO.register_course,
                register_email = registerDTO.register_email,
                register_name = registerDTO.register_name,
                register_phone = registerDTO.register_phone,
                register_status = registerDTO.register_status,
                register_message = registerDTO.register_message
            };
            return register;
        }
    }
}
