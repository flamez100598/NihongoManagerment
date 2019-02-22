using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataRevenue
    {
        public List<RevenueDTO> ConvertDataRevenueToDTO(List<Student> listStudent)
        {
            var listST =
                from student in listStudent
                group student by student.StudentClassID;

            var listRevenueDTO = new List<RevenueDTO>();
            foreach(var newGroup in listST)
            {
                var nameClass = newGroup.FirstOrDefault().Class.ClassName;
                var totalPrice = newGroup.FirstOrDefault().Class.ClassAmountStudent * newGroup.FirstOrDefault().Class.Course.Price;
                var finishPrice = 0;
                foreach(var st in newGroup)
                {
                    if(st.StudentSchoolFeeStatus == true)
                    {
                        finishPrice += (int)st.StudentSchoolFee;
                    }
                }
                var inDebt = (int)totalPrice - finishPrice;
                RevenueDTO revenue = new RevenueDTO()
                {
                    ClassName = nameClass,
                    FinishPrice = finishPrice,
                    InDebt = inDebt,
                    TotalPrice = (int)totalPrice
                };
                if(revenue != null)
                {
                    listRevenueDTO.Add(revenue);
                }
            }
            return listRevenueDTO;
        }

        
    }
}
