using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class LeaveRequestFiltersDto
    {
        public int? Month { get; set; }

        public int? Year { get; set; }
    }
}
