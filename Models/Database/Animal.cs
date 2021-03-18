using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo_Management.Models.Database
{

    public enum Sex {
        Male,
        Female
    }
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        
        [ForeignKey("Species")]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public string Name {get; set;}

        public Sex Sex { get; set; }

        public DateTime DOB {get; set;}

        public DateTime DateAcquired {get; set;}
    

    }
}
