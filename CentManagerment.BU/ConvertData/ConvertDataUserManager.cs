using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataUserManager
    {
        public UserManagerDTO ConvertDataUserManagerToDTO(UserManager userManager)
        {
            var userManagerDTO = new UserManagerDTO()
            {
                UserId = userManager.UserId,
                UserName = userManager.UserName,
                UserPassword = userManager.UserPassword,
                FullName = userManager.FullName,
                UserPhoneNumber = userManager.UserPhoneNumber,
                UserType =userManager.UserType
            };
            return userManagerDTO;
        }
        public UserManager ConvertDataUserManagerToEF(UserManagerDTO userManagerDTO)
        {
            var userManager = new UserManager()
            {
                UserName = userManagerDTO.UserName,
                UserPassword = userManagerDTO.UserPassword,
                FullName = userManagerDTO.FullName,
                UserPhoneNumber = userManagerDTO.UserPhoneNumber,
                UserType = userManagerDTO.UserType
            };
            if (userManagerDTO.UserId > 0)
            {
                userManager.UserId = userManagerDTO.UserId;
            }
            return userManager;
        }
    }
}
