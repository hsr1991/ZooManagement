using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Zoo_Management.Models.Database
{

    public enum Classification {
        Mammal,
        Reptile,
        Bird,
        Insect,
        Fish,
        Invertebrate
    }
    public class Species
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeciesId { get; set; }
        public string SpeciesType { get; set; }

        public Classification Classification { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}