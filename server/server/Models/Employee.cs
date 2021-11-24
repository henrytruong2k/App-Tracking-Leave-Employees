using Microsoft.EntityFrameworkCore;
using server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Employee : ITiming
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }

        public int Dayoff { get; set; }

        [ForeignKey("ApproverId")]
        public int ApproverId { get; set; }

        public virtual Employee Approver { get; set; }

        public string Role { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }

        [NotMapped]
        public virtual List<LeaveRequest> LeaveRequests { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
