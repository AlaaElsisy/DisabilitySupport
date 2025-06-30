public class HelperServiceDetailsDto
{
    public int? Id { get; set; }
    public string? Description { get; set; }
    public decimal? PricePerHour { get; set; }
    public DateTime? AvailableDateFrom { get; set; }
    public DateTime? AvailableDateTo { get; set; }
    public int? HelperId { get; set; }
    public string? HelperImage { get; set; } 
    public string? HelperName { get; set; }
    public int ServiceCategoryId { get; set; }
    public string? ServiceCategoryName { get; set; } 
}