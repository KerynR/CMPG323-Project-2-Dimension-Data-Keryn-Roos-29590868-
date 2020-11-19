using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class Employee
    {

        private string connectionString = "Data Source=dimensiondataserver20.database.windows.net;Initial Catalog=DataDimensionDB;User ID=azureuser;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Key]
        public int EmployeeNumer { get; set; }
        public int? ID { get; set; }
        public int? EmpID { get; set; }
        public int? empHistoryID { get; set; }
        public int? educationID { get; set; }
        public int? SurveyID { get; set; }
        public int? empPerformanceID { get; set; }
        public int? JobID { get; set; }

        public virtual EmployeeDetails Details { get; set; }
        public virtual EmployeeEducation Education { get; set; }
        public virtual EmployeeHistory History { get; set; }
        public virtual JobInformation Job { get; set; }
        public virtual CostToCompany Pay { get; set; }
        public virtual EmployeePerformance Performance { get; set; }
        public virtual Surveys Survey { get; set; }
    }
}
