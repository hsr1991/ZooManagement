using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Zoo_Management.Models.Request;
using Zoo_Management.Models.Database;

namespace Zoo_Management.Repositories
{
    public interface ISpeciesRepo
    {
        Species GetBySpecies(string type);
        Species GetBySpeciesId(int id);

        List<string> GetListOfSpecies();
    }

    public class SpeciesRepo : ISpeciesRepo 
    {

        private readonly ZooManagementDbContext _context;

        public SpeciesRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        
        public Species GetBySpecies(string type)
        {
            return _context.Species
                .Single(species => species.SpeciesType == type);
        }
        public Species GetBySpeciesId(int id)
        {
            return _context.Species
                .Single(species => species.SpeciesId == id);
        }

        public List<string> GetListOfSpecies()
        {
            return _context.Species.Select(x => x.SpeciesType).ToList();
        }
    }


}