using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class Employee
    {

        private string connectionString = "Data Source=dimensiondataserver20.database.windows.net;Initial Catalog=DataDimensionDB;User ID=azureuser;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public int EmployeeNumer { get; set; }
        public string PayID { get; set; }
        public string EmpID { get; set; }
        public string empHistoryID { get; set; }
        public string educationID { get; set; }
        public string SurveyID { get; set; }
        public string empPerformanceID { get; set; }
        public string JobID { get; set; }

        public virtual EmployeeDetails Details { get; set; }
        public virtual EmployeeEducation Education { get; set; }
        public virtual EmployeeHistory History { get; set; }
        public virtual JobInformation Job { get; set; }
        public virtual CostToCompany Pay { get; set; }
        public virtual EmployeePerformance Performance { get; set; }
        public virtual Surveys Survey { get; set; }
    }
}
