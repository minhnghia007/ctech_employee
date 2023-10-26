using System.Collections.Generic;

namespace ProjectApiCompanyCTECH.Common
{
    public class PagedResult<T> : PaperResultBase
    {
        public List<T> Items { get; set; }
    }
}
