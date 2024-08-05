using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtra.Models
{
    public class Employees
    {
        [Key]
        public int ID { get; set; }
        public string EmpNum { get; set; }
        public string Name { get; set; }
        public decimal HrsToWork { get; set; }
        public string Signature { get; set; }
        public int status { get; set; }
        public decimal? HrsWorked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int RequestID { get; set; }
        public Request Request { get; set; }
    }
}
