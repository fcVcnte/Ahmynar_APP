namespace Ahmynar_MVC.Models
{
    public class DashboardVM
    {
        public List<DashboardGraphVM> Graphs { get; set; }
        public int OpenBudgets { get; set; }
        public int OpenServiceOrders { get; set; }
        public int SellBudgets { get; set; }
        public int SellProducts { get; set; }
    }

    public class DashboardGraphVM
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public int TotalBudgets { get; set; }
        public int TotalSale { get; set; }
        public int TotalServiceOrder { get; set; }
    }
}
