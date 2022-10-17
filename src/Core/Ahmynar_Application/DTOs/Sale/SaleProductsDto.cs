using Ahmynar_Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale
{
    public class SaleProductsDto : SaleDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
