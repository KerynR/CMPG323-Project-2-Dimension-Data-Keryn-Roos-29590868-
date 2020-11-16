using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class EmployeeHistory
    {
        public string empHistoryID { get; set; }
        public string NumCompaniesWorked { get; set; }
        public string TotalWorkingYears { get; set; }
        public string YearsAtCompany { get; set; }
        public string YearsInCurrentRole { get; set; }
        public string YearsSinceLastPromotion { get; set; }
        public string YearsWithCurrManager { get; set; }
        public string TrainingTimesLastYear { get; set; }
    }
}
