using SuperHeroWeb.Models;

namespace SuperHeroWeb.Business.Interfaces
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllSuperHeros();
        SuperHero GetSuperHeroById(int id);
        void AddSuperHero(SuperHero superHero);
        void UpdateSuperHero(int id, SuperHero superHero);
        void DeleteSuperHero(int id);
    }
}
