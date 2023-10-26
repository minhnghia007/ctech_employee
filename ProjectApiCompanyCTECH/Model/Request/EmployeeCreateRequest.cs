using System;

namespace ProjectApiCompanyCTECH.Model.Request
{
    public class EmployeeCreateRequest
    {
        public string Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public decimal Salary { get; set; }
        public int? Department { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
    }
}
