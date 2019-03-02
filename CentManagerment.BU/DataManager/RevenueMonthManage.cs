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

    public class RevenueMonthManage
    {
        CentManagermentEntities db = null;
        public RevenueMonthManage()
        {
            db = new CentManagermentEntities();
        }

        public List<RevenueMonthDTO> ListRevenueMonth(DateTime? date)
        {
            if (date != null)
            {
                var listsDTO = new List<RevenueMonthDTO>();
                int Year = date.Value.Year, Month = date.Value.Month;
                var getLists = db.RevenueMonths.Where(x => x.Time.Value.Year == Year && x.Time.Value.Month == Month).ToList();

                foreach (var rm in getLists)
                {
                    var newsubrm = new ConvertDataRevenueMonth().ConvertDataRevenueMonthToDTO(rm);
                    listsDTO.Add(newsubrm);
                }
                return listsDTO;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(RevenueMonthDTO dto)
        {
            return new RevenueMonthDAO().Insert(new ConvertDataRevenueMonth().ConvertDataRevenueMonthToEF(dto));
        }
        public bool Update(int Period, int IdRM)
        {
            try
            {

                return new RevenueMonthDAO().Update(Period, IdRM);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
