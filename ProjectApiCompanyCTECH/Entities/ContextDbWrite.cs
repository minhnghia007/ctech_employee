using Microsoft.EntityFrameworkCore;

namespace ProjectApiCompanyCTECH.Entities
{
    public class ContextDbWrite : SdkEntities
    {
        public ContextDbWrite(DbContextOptions<ContextDbWrite> options) : base(options)
        {
        }
    }
}
