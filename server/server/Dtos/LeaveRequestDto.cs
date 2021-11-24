using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class LeaveRequestDto : ITiming
    {
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Reason { get; set; }

        
        public int CreatedById { get; set; }
        public virtual EmployeeDto CreatedBy { get; set; }

        public int RequestedById { get; set; }
        public virtual EmployeeDto RequestedBy { get; set; }

        public bool? Approved { get; set; }
        public DateTime DateActioned { get; set; }

        public bool IsSuccess { get; set; }
        public string MessageResponse { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
