using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using Zoo_Management.Models.Database;
using Zoo_Management.Models.Request;
using Zoo_Management.Models.Response;
using Zoo_Management.Repositories;

namespace Zoo_Management.Data
{

    public static class SampleAnimal
    {
        public static IList<string> _names = new List<string>
        {
           
                "Buddy",
                "Inky",
                "Blinky",
                "Pinky",
                "Clyde",
                "Bart",
                "Lisa",
                "Maggie",
                "Homer",
                "Snowball",
                "Marge",
                "Santas Little Helper",
                "Cloud",
                "Ghost",
                "Jasper",
                "Whistler",
                "Kyrie",
                "Kobe",
                "Fenton",
                "Oscar",
                "Mufusa",
                "Simba",
                "Timone",
                "Pumba",
                "Zazu",
                "Iago",
                "Abu",
                "Olaf",
                "Raja",
                "Mr Potato Head",
                "Hedwig",
                "Tim",
                "Scabbers",
                "Malfoy",
                "Voldemort",
                "Bo Peep",
                "Buzz",
                "Woody",
                "Abz",
                "Cherine",
                "James",
                "Megan",
                "Rachel",
                "Salma",
                "Esme",
                "Jenna",
                "Lottie",
                "Charlie",
                "Josh",
                "Sam",
                "Tony",
                "Amy",
                "Caroline",
                "Hannah",
                "Greg",
                "Suzy",
                "Lenny",
                "Chocolate",
                "Ashley",
                "Terry",

          
        };

        public static IList<(string, Classification)> _species = new List<(string, Classification)>
        {

           ("Armadillo", Classification.Mammal),
           ("Elephant", Classification.Mammal),
           ("Lion", Classification.Mammal),
           ("Penguin", Classification.Bird),
           ("Zebra", Classification.Mammal),
           ("Pelican", Classification.Bird),
           ("Camel", Classification.Mammal),
           ("Snake", Classification.Reptile),
           ("Rhino", Classification.Mammal),
           ("Badger", Classification.Mammal),
           ("Cheetah", Classification.Mammal),
           ("Orangutan", Classification.Mammal),
           ("Chimpanzee", Classification.Mammal),
           ("Frog", Classification.Amphibian),
           ("Parrot", Classification.Bird),
           ("Toad", Classification.Amphibian),
           ("Crab", Classification.Invertebrate),
           ("Puffer fish", Classification.Fish),
           ("Pirahna", Classification.Fish),
           ("Octopus", Classification.Mollousc),
           ("Ant", Classification.Invertebrate),
           ("Scorpion", Classification.Invertebrate),
           ("Lemur", Classification.Mammal),
           ("Gibbon", Classification.Mammal),
           ("Giraffe", Classification.Mammal),
           ("Meerkat", Classification.Mammal),
           ("Donkey", Classification.Mammal),
           ("Horse", Classification.Mammal),
           ("Stingray", Classification.Fish),
           ("Coyote", Classification.Mammal),
           ("Polar Bear", Classification.Mammal),
           ("Grizzly Bear", Classification.Mammal),
           ("Moose", Classification.Mammal),
           ("Albatros", Classification.Bird),
           ("Kiwi", Classification.Bird),
           ("Dodo", Classification.Bird),
           ("Goat", Classification.Mammal),
           ("Teenage Mutant Ninja Turtle", Classification.Reptile),
           ("Pikachu", Classification.Mammal),
           ("Liger", Classification.Mammal),
           ("Bottle Nose Dolphin", Classification.Mammal),
           ("Centaur", Classification.Mammal),
           ("Basilisk", Classification.Reptile),
           ("Dire Wolf", Classification.Mammal),
           ("Manta Ray", Classification.Fish),
           ("Tyrannosaurus Rex", Classification.Reptile),
           ("Unicorn", Classification.Mammal),
           ("Komodo Dragon", Classification.Reptile),
           ("Orca", Classification.Mammal),
           ("Great White Shark", Classification.Fish),
           ("Mongoose", Classification.Mammal),
           ("Echidna", Classification.Mammal),
           ("Cobra", Classification.Reptile),
           ("Warthog", Classification.Mammal),
           ("Axolotl", Classification.Amphibian),
           ("Clown Fish", Classification.Fish),
           ("Rattle Snake", Classification.Reptile),
           ("Bearded Dragon", Classification.Reptile)



        };

        public static IEnumerable<Species> GetSpecies()
        {
            return Enumerable.Range(0, _species.Count()).Select(CreateSpecies);
        }
       

        public static Species CreateSpecies(int index)
        {
            

            return new Species
            {
                SpeciesType = _species[index].Item1,
                Classification = _species[index].Item2 
            };
        }

        public static Random r = new Random();
        
        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(1, 20).Select(CreateAnimal);
        }
        
        public static Animal CreateAnimal(int index)
        {
            var speciesId = r.Next(1, _species.Count() + 1);
            var name = _names[r.Next(0, _names.Count() + 1)];
            var sex = r.Next(0, 2);
            DateTime DOB = new DateTime(2010, 09, 03);
            DateTime dateAcquired = new DateTime(2012, 12, 25);



            return new Animal
            {
                SpeciesId = speciesId,
                Name = name.ToString(),
                Sex = (Sex)Enum.Parse(typeof(Sex), sex.ToString()),
                DOB = DOB,
                DateAcquired = dateAcquired

            };

        }



    }



}