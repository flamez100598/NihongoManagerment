using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataExpenditure
    {
        /// <summary>
        /// chuyển đổi dữ liệu bảng thu chi từ EF sang DTO
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public ExpenditureDTO ConvertDataExpenditureToDTO(Expenditure cl)
        {
            var ExpenditureDTO = new ExpenditureDTO()
            {
                ExpenditureId = cl.ExpenditureId,
                ExpenditureName = cl.ExpenditureName,
                Price = cl.Price
               
            };
            return ExpenditureDTO;
        }
        /// <summary>
        /// Chuyển đổi dữ liệu bảng thu chi từ DTO sang EF
        /// </summary>
        /// <param name="ExpenditureDTO"></param>
        /// <returns></returns>
        public Expenditure ConvertDataExpenditureToEF(ExpenditureDTO ExpenditureDTO)
        {
            var ExpenditureEF = new Expenditure()
            {
                ExpenditureName = ExpenditureDTO.ExpenditureName,
                Price = ExpenditureDTO.Price
            };
            if (ExpenditureDTO.ExpenditureId > 0)
            {
                ExpenditureEF.ExpenditureId = ExpenditureDTO.ExpenditureId;
            }
            return ExpenditureEF;
        }
    }
}
