using Ahmynar_Application.DTOs.Common;
using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Budget
{
    public class UpdateBudgetDto : BaseDto, IBudgetDto
    {
        public long Number { get; set; }
        public Ahmynar_Domain.Enums.StatusDescription Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public float? TotalServices { get; set; }
        public float? TotalProducts { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int CustomerId { get; set; }
        public List<int> ServiceIds { get; set; }
        public List<int>? ProductIds { get; set; }
    }
}
