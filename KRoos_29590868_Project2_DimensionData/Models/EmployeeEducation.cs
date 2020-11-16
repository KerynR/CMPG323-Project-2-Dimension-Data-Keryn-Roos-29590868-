using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class EmployeeEducation
    {
        [Key]
        public string EducationID { get; set; }
        public string Education { get; set; }
        public string EducationField { get; set; }
    }
}
