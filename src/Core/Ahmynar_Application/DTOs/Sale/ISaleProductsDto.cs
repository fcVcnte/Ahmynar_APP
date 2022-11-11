using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale
{
    public interface ISaleProductsDto : ISaleDto
    {
        public Ahmynar_Domain.Enums.TypeSale TypeSale { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
