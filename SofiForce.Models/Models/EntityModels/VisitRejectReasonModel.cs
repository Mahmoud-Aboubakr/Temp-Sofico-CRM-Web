namespace SofiForce.Models.Models.EntityModels;
public class VisitRejectReasonModel
{
    public int VisitRejectReasonId { get; set; }
    public string? VisitRejectReasonCode { get; set; }
    public string? VisitRejectReasonNameEn { get; set; }
    public string? VisitRejectReasonNameAr { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? CanEdit { get; set; }
    public bool? CanDelete { get; set; }
    public int? DisplayOrder { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
    public int? CBy { get; set; }
    public DateTime? CDate { get; set; }
    public int? EBy { get; set; }
    public DateTime? EDate { get; set; }
}
