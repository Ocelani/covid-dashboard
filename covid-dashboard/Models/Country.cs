using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace covid_dashboard.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [Display(Name="Code")]
        public int Id { get; set; }

        [Display(Name="Country")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        // [ForeignKey("StatusId")]
        //public CountryStatus Status { get; set; }
    }
}
