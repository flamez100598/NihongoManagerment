using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataRevenueMonth
    {
        public RevenueMonthDTO ConvertDataRevenueMonthToDTO(RevenueMonth RevenueMonth)
        {
            var RevenueMonthDTO = new RevenueMonthDTO()
            {
                Id = RevenueMonth.Id,
                ClassId = RevenueMonth.ClassId,
                Period = RevenueMonth.Period,
                Time = RevenueMonth.Time,
            };
            if(RevenueMonth.Class != null)
            {
                RevenueMonthDTO.ClassDTO = new ConvertDataClass().ConvertDataClassToDTO(RevenueMonth.Class);
                RevenueMonthDTO.Money = RevenueMonth.Class.Course.Price / RevenueMonth.Class.Course.TotalPeriod;
            }
            return RevenueMonthDTO;
        }
        public RevenueMonth ConvertDataRevenueMonthToEF(RevenueMonthDTO RevenueMonthDTO)
        {
            var RevenueMonthEF = new RevenueMonth()
            {
                Id = RevenueMonthDTO.Id,
                ClassId = RevenueMonthDTO.ClassId,
                Period = RevenueMonthDTO.Period,
                Time = RevenueMonthDTO.Time,

            };
            if (RevenueMonthDTO.Id > 0)
            {
                RevenueMonthEF.Id = RevenueMonthDTO.Id;
            }
            return RevenueMonthEF;
        }
    }
}
