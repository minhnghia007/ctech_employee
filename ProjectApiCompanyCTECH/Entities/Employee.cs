using ProjectApiCompanyCTECH.MainEntitites;
using System;

namespace ProjectApiCompanyCTECH.Entities
{
    public class Employee : IAggregateRoot
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public Decimal Salary { get; set; }
        public int? Department { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime? Create_Date { get; set; }
        public DateTime? Modified_Date { get; set; }
    }
}
