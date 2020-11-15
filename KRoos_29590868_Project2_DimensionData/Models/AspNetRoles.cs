using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class AspNetRoles
    {
        [Key]
        public int Id { get; set; }

        public string RoleId { get; set; }

        public string ClaimType { get; set; }

        public string Claimvalue { get; set; }

        public virtual AspNetRoles Role { get; set; }
    }
}
