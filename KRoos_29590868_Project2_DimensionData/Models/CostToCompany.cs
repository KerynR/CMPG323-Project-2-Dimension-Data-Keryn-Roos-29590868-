using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class CostToCompany
    {
        
        [Key]
        public string PayID { get; set; }
        public string HourlyRate { get; set; }
        public string MonthlyRate { get; set; }
        public string MonthlyIncome { get; set; }
        public string DailyRate { get; set; }
        public string OverTime { get; set; }
        public string PercentageSalaryHike { get; set; }
    }
}
