using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class MaritalStatus
    {
        [Key]
        public string MaritalID { get; set; }

        private string maritalStatus;

        public string GetMaritalStatus()
        {
            return maritalStatus;
        }

        public void SetMaritalStatus(string value)
        {
            maritalStatus = value;
        }
    }
}
