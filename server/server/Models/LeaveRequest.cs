using server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class LeaveRequest : ITiming
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Reason { get; set; }

        [ForeignKey("CreatedById")]
        public int CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }

        [ForeignKey("RequestedById")]
        public int RequestedById { get; set; }
        public virtual Employee RequestedBy { get; set; }

        public bool? Approved { get; set; }
        public DateTime DateActioned { get; set; }

        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
