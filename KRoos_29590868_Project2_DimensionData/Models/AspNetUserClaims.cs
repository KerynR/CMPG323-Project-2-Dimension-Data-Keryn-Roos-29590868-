using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class AspNetUserClaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
