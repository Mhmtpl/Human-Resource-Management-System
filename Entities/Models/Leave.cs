using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }       
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
