using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class RegisterManager
    {
        public bool StudentManagerInsert(RegisterManagermentDTO registerDTO)
        {
            try
            {
                return new RegisterDAO().Insert(new ConvertDataRegisterManagerment().ConvertDataRegisterToEF(registerDTO));
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
