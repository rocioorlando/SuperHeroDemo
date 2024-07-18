
using SuperHeroWeb.Business.Interfaces;
using SuperHeroWeb.Models;

namespace SuperHeroWeb.Business
{
    public class SuperHeroService: ISuperHeroService
    {
        private readonly List<SuperHero> superHeros;

        public SuperHeroService()
        {
            superHeros = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Superman", SuperPowers = "Super strength, flight, heat vision", Team = "Justice League", Level = 10 },
                new SuperHero { Id = 2, Name = "Wonder Woman", SuperPowers = "Super strength, flight, Lasso of Truth", Team = "Justice League", Level = 9 },
                new SuperHero { Id = 3, Name = "Spider-Man", SuperPowers = "Wall-crawling, spider sense, web-shooters", Team = "Avengers", Level = 8 }
            };
        }

        public List<SuperHero> GetAllSuperHeros()
        {
            return superHeros;
        }

        public SuperHero GetSuperHeroById(int id)
        {
            return superHeros.FirstOrDefault(sh => sh.Id == id);
        }

        public void AddSuperHero(SuperHero superHero)
        {
            if (superHero == null)
            {
                throw new ArgumentNullException(nameof(superHero));
            }

            superHero.Id = superHeros.Count + 1; 
            superHeros.Add(superHero);
        }

        public void UpdateSuperHero(int id, SuperHero superHero)
        {
            if (superHero == null)
            {
                throw new ArgumentNullException(nameof(superHero));
            }

            var index = superHeros.FindIndex(sh => sh.Id == id);
            if (index != -1)
            {
                superHeros[index] = superHero;
            }
            else
            {
                throw new KeyNotFoundException($"Super héroe con ID {id} no encontrado.");
            }
        }


        public void DeleteSuperHero(int id)
        {
            superHeros.RemoveAll(sh => sh.Id == id);
        }
    }
}
