using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using CentManagerment.Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class RegisterManager
    {
        ConvertDataRegisterManagerment convertData = new ConvertDataRegisterManagerment();
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

        public bool StudentManagerUpdate(int idRegister, int status)
        {
            try
            {
                return new RegisterDAO().Update(idRegister, status);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool StudentManagerDelete(int idRegister)
        {
            try
            {
                return new RegisterDAO().Delete(idRegister);
            }
            catch (Exception)
            {

                return false;
            }
        }


        public IEnumerable<RegisterManagermentDTO> GetListRegistersAndPaging(string searchString, int page, int pageSize)
        {
            List<RegisterManagermentDTO> listDTOs = new List<RegisterManagermentDTO>();
            List<RegisterManagerment> listEFs = new List<RegisterManagerment>();
            using (var db = new CentManagermentEntities())
            {
                listEFs = db.RegisterManagerments.ToList();

            }
            foreach (var ef in listEFs)
            {
                listDTOs.Add(convertData.ConvertDataRegisterToDTO(ef));
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                listDTOs = listDTOs.Where(x => x.register_course.ToString().Contains(searchString) || x.register_message.Contains(searchString) || x.register_email.Contains(searchString)
                || x.register_name.Contains(searchString) || x.register_phone.Contains(searchString)).ToList();
            }
            return listDTOs.ToPagedList(page, pageSize);
        }
    }
}
