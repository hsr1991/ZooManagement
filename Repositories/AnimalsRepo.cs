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

        int Count(AnimalSearchRequest search);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
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

            var species = _context.Species.Single(x => x.SpeciesType == newAnimal.SpeciesType);

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

        public int Count(AnimalSearchRequest search)
        {
             var context = _context.Animals.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                context = context.Where(x => x.Name.ToLower() == search.Name.ToLower());
            }
            if (search.Age != null)
            {
                context = context.Where(x => DateTime.Now.Year - x.DOB.Year == search.Age );
            }
            if (!String.IsNullOrEmpty(search.SpeciesType))
            {
                context = context.Where(x => x.Species.SpeciesType.ToLower() == search.SpeciesType.ToLower());
            }
            if (!String.IsNullOrEmpty(search.Classification))
            {
                context = context.Where(x => x.Species.Classification.ToString().ToLower() == search.SpeciesType.ToLower());
            }
            if (!String.IsNullOrEmpty(search.Sex))
            {
                context = context.Where(x => x.Sex.ToString().ToLower() == search.Sex.ToLower());
            }
            if (search.DateAcquired != null)
            {
                context = context.Where(x => x.DateAcquired == search.DateAcquired);
            }

            return context.Count();
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            var context = _context.Animals.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                context = context.Where(x => x.Name.ToLower() == search.Name.ToLower());
            }
            if (search.Age != null)
            {
                context = context.Where(x => DateTime.Now.Year - x.DOB.Year == search.Age );
            }
            if (!String.IsNullOrEmpty(search.SpeciesType))
            {
                context = context.Where(x => x.Species.SpeciesType.ToLower() == search.SpeciesType.ToLower());
            }
            if (!String.IsNullOrEmpty(search.Classification))
            {
                context = context.Where(x => x.Species.Classification.ToString().ToLower() == search.SpeciesType.ToLower());
            }
            if (!String.IsNullOrEmpty(search.Sex))
            {
                context = context.Where(x => x.Sex.ToString().ToLower() == search.Sex.ToLower());
            }
            if (search.DateAcquired != null)
            {
                context = context.Where(x => x.DateAcquired == search.DateAcquired);
            }




            return context.Include(x => x.Species).OrderBy(x => x.Species.SpeciesType);
            // return _context.Animals
            //     .OrderByDescending(p => p.Species.SpeciesType)
            //     .Where(p => search.PostedBy == null || p.UserId == search.PostedBy)
            //     .Skip((search.Page - 1) * search.PageSize)
            //     .Take(search.PageSize);
        }


    }


}