using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class HandleLeaveRequestDto
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
    }
}
