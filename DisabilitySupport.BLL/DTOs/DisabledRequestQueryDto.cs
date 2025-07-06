using System;

namespace DisabilitySupport.BLL.DTOs
{
    public class DisabledRequestQueryDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? DisabledId { get; set; }
        public int? HelperServiceId { get; set; }
        public string? Status { get; set; }
        public string? SearchWord { get; set; }
        public int? CategoryId { get; set; }
    }
} 