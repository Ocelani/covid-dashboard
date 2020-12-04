using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace covid_dashboard.Models
{
    [Table("CountryStatuses")]
    public class CountryStatus
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CountryId")]
        [Required(ErrorMessage = "Field required.")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name = "Casos confirmados")]
        public int CasosConfirmados { get; set; }

        [Display(Name = "Mortes")]
        public int Mortes { get; set; }

        [Display(Name = "Recuperados")]
        public int Recuperados { get; set; }
    }
}
