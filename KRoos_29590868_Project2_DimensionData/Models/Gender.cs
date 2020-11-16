using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }

        private string gender;

        public string GetGender()
        {
            return gender;
        }

        public void SetGender(string value)
        {
            gender = value;
        }
    }
}
