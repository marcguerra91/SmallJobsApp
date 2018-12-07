using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallJob.Models
{
    public class WorkerListItem
    {
        [Display(Name="Worker ID")]
        public int WorkerId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = FirstName + " " + LastName; }
        }


        public override string ToString() => LastName;
    }
}
