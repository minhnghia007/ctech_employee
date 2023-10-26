using Microsoft.AspNetCore.Http;
using ProjectApiCompanyCTECH.Common;
using ProjectApiCompanyCTECH.MainEntitites;
using System;

namespace ProjectApiCompanyCTECH.Entities
{
    public class Employee : IAggregateRoot
    {
        public int Id                    { get; set; }
        public string Fullname           { get; set; }
        public DateTime? Birthday        { get; set; }
        public bool? Gender              { get; set; }
        public string Email              { get; set; }
        public string PhoneNumber        { get; set; }
        public Decimal Salary            { get; set; }
        public DepartmentEnum Department { get; set; }
        public string Image              { get; set; }
        public string Biography          { get; set; }
        public DateTime? CreateDate      { get; set; }
        public DateTime? ModifiedDate    { get; set; }
    }
}
