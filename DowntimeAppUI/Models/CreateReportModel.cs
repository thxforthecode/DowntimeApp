using System.ComponentModel.DataAnnotations;

namespace DowntimeAppUI.Models;

public class CreateReportModel
{
   [Required]
   [MaxLength(100)]
   public string Issue { get; set; }

   [Required]
   [MaxLength(200)]
   public string Solution { get; set; }

   [Required]
   [MinLength(1)]
   [Display(Name = "Machine")]
   public string MachineId { get; set; }
}
