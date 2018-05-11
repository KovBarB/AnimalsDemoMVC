using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAnimalSearch.Models
{
    public class Organisation
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid OrgId { get; set; }

        [StringLength(50)]
        [Display(Name = "Név")]
        public string Name { get; set; }  

        [Display(Name = "Weboldal")]
        [Url(ErrorMessage = "Nem megfelelő formátum.")]
        public string URL { get; set; }
        [Display(Name = "Bemutatkozás")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string About { get; set; }

        public virtual List<Animal> RelatedAnimals { get; set; }
        public virtual List<ApplicationUser> OrgMembers { get; set; }
    }
}