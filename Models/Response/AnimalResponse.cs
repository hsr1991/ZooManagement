using System;
using Zoo_Management.Models.Database;

namespace Zoo_Management.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;
        private readonly Species _species;

        public AnimalResponse(Animal animal, Species species)
        {
            _animal = animal;
            _species = species;
        }

        public int Id => _animal.AnimalId;
        public int SpeciesId => _animal.SpeciesId;
        public string SpeciesType => _species.SpeciesType;
        public string Classification => _species.Classification.ToString();
        
        public string Name => _animal.Name;
        public string Sex => _animal.Sex.ToString();
        public DateTime DOB => _animal.DOB;
        public DateTime DateAcquired => _animal.DateAcquired;
        
    }


    public class AnimalResponse2
    {
        private readonly Animal _animal;
        

        public AnimalResponse2(Animal animal)
        {
            _animal = animal;
            
        }

        public int Id => _animal.AnimalId;
        public int SpeciesId => _animal.SpeciesId;
        public string SpeciesType => _animal.Species.SpeciesType;
        public string Classification => _animal.Species.Classification.ToString();
        public string Name => _animal.Name;
        public string Sex => _animal.Sex.ToString();
        public DateTime DOB => _animal.DOB;
        public DateTime DateAcquired => _animal.DateAcquired;
        
    }

}

