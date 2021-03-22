using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zoo_Management.Models.Database;
using Zoo_Management.Models.Request;
using Zoo_Management.Models.Response;
using Zoo_Management.Repositories;
using Zoo_Management.Data;



namespace Zoo_Management.Controllers
{
    [ApiController]
    [Route("/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;
        private readonly ISpeciesRepo _species;
        private readonly ILogger<AnimalsController> _logger;
        public AnimalsController(IAnimalsRepo animals, ISpeciesRepo species, ILogger<AnimalsController> logger)
        {
            _animals = animals;
            _species = species;
            _logger = logger;
        }
     
       

         [HttpGet("{id}")]
            public ActionResult<AnimalResponse> GetById([FromRoute] int id)
            {
                var animal = _animals.GetByAnimalId(id);
                
                var species = _species.GetBySpeciesId(animal.SpeciesId);
                //don't have to go to database to get species id
                return new AnimalResponse(animal, species);
            }

        [HttpPost("add")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var animal = _animals.Create(newAnimal);
            var species =  _species.GetBySpecies(newAnimal.SpeciesType);
            //var url = Url.Action("GetById", new { id = animal.AnimalId });
            var responseViewModel = new AnimalResponse(animal, species);
            return Created("test", responseViewModel);  
            
        }
        
        [HttpGet("list")]
        public ActionResult<SpeciesListResponse> ListSpecies()
        {
            var species =_species.GetListOfSpecies();
            return new SpeciesListResponse(species);
        }

        [HttpGet("")]
        public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            var animals = _animals.Search(searchRequest);
            var animalCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalCount);
        }

        

       
            
        


        // [HttpGet]
        // public IEnumerable<Animal> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new Animal
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
