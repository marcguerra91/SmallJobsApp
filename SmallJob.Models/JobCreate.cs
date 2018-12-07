using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class JobCreate
    {
        [Required]
        [Display(Name ="Title of job")]
        public string TitleOfJob { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(10, 200, ErrorMessage = "Pay range is between $10-$200")]
        public int Pay { get; set; }

        [Required]
        [Display(Name ="Equipment available")]
        public bool EquipmentAvailable { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
