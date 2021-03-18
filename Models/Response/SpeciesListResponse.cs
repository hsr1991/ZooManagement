using System;
using System.Collections.Generic;
using Zoo_Management.Models.Database;

namespace Zoo_Management.Models.Response
{
    public class SpeciesListResponse
    {
        public List<string> species { get;set; }

       public SpeciesListResponse(List<string> Species)
        {
            species = Species;
        }

       
          
    }
}