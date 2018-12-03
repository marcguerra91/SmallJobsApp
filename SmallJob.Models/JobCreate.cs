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
        public string TitleOfJob { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(10, 200, ErrorMessage = "Pay range is between $10-$200")]
        public int Pay { get; set; }

        [Required]
        public bool EquipmentAvailable { get; set; }

        public override string ToString() => TitleOfJob;
    }
}
