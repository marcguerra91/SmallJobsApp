using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class JobEdit
    {
        [Display(Name ="Job ID")]
        public int JobId { get; set; }

        [Display(Name ="Title Of Job")]
        public string TitleOfJob { get; set; }

        public string Description { get; set; }

        [Range(10, 200, ErrorMessage = "Pay range is between $10-$200")]
        public int Pay { get; set; }

        [Display(Name ="Equipment Available")]
        public bool EquipmentAvailable { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
