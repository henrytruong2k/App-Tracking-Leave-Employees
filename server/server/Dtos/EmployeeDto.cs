using System.Collections.Generic;

namespace server.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Dayoff { get; set; }

        public string Role { get; set; }

        public int ApproverId { get; set; }

        public virtual EmployeeDto Approver { get; set; }

        public string AccessToken { get; set; }
    }
}
