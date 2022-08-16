﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Budget
{
    public class BudgetListDto
    {
        public long Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public float TotalDiscounts { get; set; }
        public float Total { get; set; }
        public int CustomerId { get; set; }
    }
}
