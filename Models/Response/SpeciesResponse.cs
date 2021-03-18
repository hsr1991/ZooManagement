using System;
using Zoo_Management.Models.Database;

namespace Zoo_Management.Models.Response
{
    public class SpeciesResponse
    {
        private readonly Species _species;

        public SpeciesResponse(Species species)
        {
            _species = species;
        }

        public int Id => _species.SpeciesId;
        public string SpeciesType => _species.SpeciesType;
        public Classification Classification => _species.Classification;
          
    }
}