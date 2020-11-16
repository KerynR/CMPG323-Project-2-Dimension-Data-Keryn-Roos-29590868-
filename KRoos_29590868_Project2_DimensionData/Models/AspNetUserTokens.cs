using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRoos_29590868_Project2_DimensionData.Models
{
    public class AspNetUserTokens
    {
        public int Id { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
