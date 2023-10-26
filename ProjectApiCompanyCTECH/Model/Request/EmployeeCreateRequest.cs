using Microsoft.AspNetCore.Http;
using ProjectApiCompanyCTECH.Common;
using System;

namespace ProjectApiCompanyCTECH.Model.Request
{
    public class EmployeeCreateRequest
    {
        public string Fullname           { get; set; }
        public DateTime? Birthday        { get; set; }
        public bool? Gender              { get; set; }
        public string Email              { get; set; }
        public string PhoneNumber        { get; set; }
        public decimal Salary            { get; set; }
        public DepartmentEnum Department { get; set; }
        public string Image              { get; set; }
        public string Biography          { get; set; }
    }
}
