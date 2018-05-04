using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewAnimalSearch.Models
{
    public class Photo
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid PhotoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid AnimalID { get; set; }

        public byte[] PhotoData { get; set; }
        //[Url(ErrorMessage = "Nem megfelelő formátum.")]
        public string URL { get; set; }
        [StringLength(50)]
        public string ContentType { get; set; }

        //[Display(Name = "Cím")]
        public string Title { get; set; }

        public virtual Animal Animal { get; set; }
    }
}