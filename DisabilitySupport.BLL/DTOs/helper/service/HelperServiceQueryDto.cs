using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.service
{
    public class HelperServiceQueryDto
    {
        public int? HelperId { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string? SearchWord { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
         public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
        public string? SortBy { get; set; }
        public string? Status { get; set; }
    }
}
