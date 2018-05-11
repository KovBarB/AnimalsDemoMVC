using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAnimalSearch.Models
{
    public enum AnimalType : byte { Kutya, Macska, Malac, Ló, Hörcsög, Nyúl, Tengerimalac, Patkány, Degu, Hüllő, Egyéb }

    public class Animal
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid ProtegeId { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Szervezet")]
        [Required(ErrorMessage = "Szervezet megadása kötelező.")]
        public Guid OrgId { get; set; }

        [Display(Name = "Fajta")]
        public AnimalType Type { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Név megadása kötelező.")]
        [Display(Name = "Név")]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Szervezetnél felvéve")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM}")]
        public DateTime RegisteredAtOrg { get; set; }

        [Range(1, 12, ErrorMessage = "A hónapok száma 1 és 12 között kell, hogy legyen.")] public int AgeMonth { get; set; }

        [Range(0, 99, ErrorMessage = "Az évek száma 0 és 99 között kell, hogy legyen.")]
        public int AgeYear { get; set; }

        [Display(Name = "Weboldal")]
        [Url(ErrorMessage = "Nem megfelelő formátum.")]
        public string URL { get; set; }
        [Display(Name = "Bemutatkozás")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string About { get; set; }

        [Display(Name = "Szevezet")]
        public virtual Organisation Org { get; set; }
        [Display(Name = "Képek")]
        public virtual List<Photo> MyPics { get; set; }       
    }
}