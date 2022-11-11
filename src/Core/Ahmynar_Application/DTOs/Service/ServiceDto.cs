using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Service
{
    public class ServiceDto : BaseDto
    {
        public string Description { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }
    }
}
