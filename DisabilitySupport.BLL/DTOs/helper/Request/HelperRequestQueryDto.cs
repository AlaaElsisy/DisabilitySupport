using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.Request
{
    public class HelperRequestQueryDto
    {
        public int? HelperId { get; set; }
        public int? DisabledOfferId { get; set; }
        public string? Status { get; set; }
        public string? SearchWord { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
