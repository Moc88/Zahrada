using System;
using System.ComponentModel.DataAnnotations;

namespace OsevniPlan.Models
{
    public class Plodina
    {
        [Display(Name = "Název plodiny")]
        public string Id { get; set; }
        [Display(Name = "Název odrůdy")]
        public string Odruda { get; set; }
        [Display(Name = "Název výrobce")]
        public string Vyrobce { get; set; }
        [Display(Name = "Datum osevu")]
        public DateTime Oseto { get; set; }
       


    }
}
