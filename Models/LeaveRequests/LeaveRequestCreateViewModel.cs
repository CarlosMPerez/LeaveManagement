﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveRequestCreateViewModel : IValidatableObject
{
    [Display(Name="Starting Date")]
    [Required]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date")]
    [Required]
    public DateTime? EndDate { get; set; }

    [Display(Name = "Comments")]
    public string? RequestComments { get; set; }

    [Display(Name = "Leave Type")]
    public SelectList? LeaveTypes { get; set; }

    [Required]
    public int LeaveTypeId { get; set; }

    /// <summary>
    /// Custom logic validation not covered by simple attributes
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate.Value.Date == EndDate.Value.Date)
            yield return new ValidationResult("Start Date and End Date cannot be the same. \n Please make sure End Date equals to your FIRST day working again.",
                                        new[] { nameof(StartDate), nameof(EndDate) });
        if (StartDate > EndDate)
            yield return new ValidationResult("Start Date cannot be after End Date",
                                        new[] { nameof(StartDate), nameof(EndDate) });

        if (RequestComments?.Length > 250) 
            yield return new ValidationResult("Comments are too long. Don't be so brasas.", 
                                        new[] { nameof(RequestComments) });
    }
}