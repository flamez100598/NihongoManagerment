using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class ExpenditureManager
    {
        CentManagermentEntities db = null;
        public bool ExpenditureManagerInsert(ExpenditureDTO Expenditure)
        {
            try
            {
                return new ExpenditureDAO().Insert(new ConvertDataExpenditure().ConvertDataExpenditureToEF(Expenditure));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ExpenditureManagerUpdate(ExpenditureDTO Expenditure)
        {
            try
            {
                return new ExpenditureDAO().Update(new ConvertDataExpenditure().ConvertDataExpenditureToEF(Expenditure));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ExpenditureManagerDelete(ExpenditureDTO Expenditure)
        {
            try
            {
                return new ExpenditureDAO().Delete(new ConvertDataExpenditure().ConvertDataExpenditureToEF(Expenditure));
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
