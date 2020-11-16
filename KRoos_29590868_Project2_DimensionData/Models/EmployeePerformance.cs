using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class EmployeePerformance
    {
        [Key]
        public string empPerformanceID { get; set; }
        public string PerformanceRating { get; set; }
        public string WorkLifeBalance { get; set; }
        public string JobInvolvement { get; set; }
    }
}
