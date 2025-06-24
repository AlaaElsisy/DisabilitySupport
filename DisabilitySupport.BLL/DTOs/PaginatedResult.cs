using System.Collections.Generic;

namespace DisabilitySupport.BLL.DTOs
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
} 