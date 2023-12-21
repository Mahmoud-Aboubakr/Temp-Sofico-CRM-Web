﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SofiForce.Models.Models.EntityModels;

public class VisitRejectReasonModel
{
    public int VisitRejectReasonId { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonCode is required")]
    public string? VisitRejectReasonCode { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonNameEn is required")]
    public string? VisitRejectReasonNameEn { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonNameAr is required")]
    public string? VisitRejectReasonNameAr { get; set; }
    public bool? IsActive { get; set; } = true;
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


public class VisitRejectReasonModel2
{
    public int VisitRejectReasonId { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonCode is required")]
    public string? VisitRejectReasonCode { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonNameEn is required")]
    public string? VisitRejectReasonNameEn { get; set; }
    [Required(ErrorMessage = "VisitRejectReasonNameAr is required")]
    public string? VisitRejectReasonNameAr { get; set; }
    [JsonIgnore]
    public bool? IsActive { get; set; } = true;
    [JsonIgnore]
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

