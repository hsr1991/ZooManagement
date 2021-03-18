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
    public interface IAnimalsRepo
    {
        Animal Create(CreateAnimalRequest newAnimal);

        Animal GetByAnimalId(int id);

    }

    public class AnimalsRepo : IAnimalsRepo 
    {

        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetByAnimalId(int id)
        {
            return _context.Animals
                .Single(animal => animal.AnimalId == id);
        }
        
        public Animal Create(CreateAnimalRequest newAnimal)
        {
            if (!_context.Species.Any(x => x.SpeciesType == newAnimal.SpeciesType))
            {
                _context.Species.Add(new Species
                {
                    SpeciesType = newAnimal.SpeciesType,
                    Classification = (Classification)Enum.Parse(typeof(Classification), newAnimal.Classification)
                });
                _context.SaveChanges();
            }

            var species =  _context.Species.Single(x => x.SpeciesType == newAnimal.SpeciesType);

            var insertResponse = _context.Animals.Add(new Animal
            {
                SpeciesId = species.SpeciesId,
                Name = newAnimal.Name,
                Sex = (Sex)Enum.Parse(typeof(Sex), newAnimal.Sex),
                DOB = newAnimal.DOB,
                DateAcquired = newAnimal.DateAcquired
            
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }
    }


}