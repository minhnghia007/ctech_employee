using System;

namespace ProjectApiCompanyCTECH.Extensions
{
    public class EmpExtensions : Exception
    {
        public EmpExtensions()
        {
        }

        public EmpExtensions(string message)
            : base(message)
        {
        }

        public EmpExtensions(string message, Exception inner)
            : base(message, inner)
        {
        }
    
}
}
