using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class Surveys
    {
        [Key]
        public string SurveyID { get; set; }
        public string EnvironmentSatisfaction { get; set; }
        public string JobSatisfaction { get; set; }
        public string RelationshipSatisfaction { get; set; }
    }
}
