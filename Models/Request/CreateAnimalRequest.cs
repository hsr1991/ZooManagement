using System.ComponentModel.DataAnnotations;
using System;
using Zoo_Management.Models.Database;

namespace Zoo_Management.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        [StringLength(70)]
        public string SpeciesType { get; set; }
        
        [Required]
        [EnumDataType(typeof(Classification))]
        public string Classification { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Sex))]
        public string Sex { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public DateTime DateAcquired {get; set;}
    }
}