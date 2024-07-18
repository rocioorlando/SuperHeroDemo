using Microsoft.AspNetCore.Mvc;
using SuperHeroWeb.Business;
using SuperHeroWeb.Business.Interfaces;
using SuperHeroWeb.Models;

namespace SuperHeroWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }

        [HttpGet]
        public IActionResult GetAllSuperHeros()
        {
            try
            {
                var superHeros = superHeroService.GetAllSuperHeros();
                return Ok(superHeros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSuperHeroById(int id)
        {
            try
            {
                var superhero = superHeroService.GetSuperHeroById(id);
                if (superhero == null)
                {
                    return NotFound($"Superhero with Id {id} not found.");
                }
                return Ok(superhero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddSuperHero([FromBody] SuperHero superHero)
        {
            try
            {
                if (superHero == null)
                {
                    return BadRequest("Invalid superhero data.");
                }

                superHeroService.AddSuperHero(superHero);

                return CreatedAtAction(nameof(GetSuperHeroById), new { id = superHero.Id }, superHero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSuperHero(int id, [FromBody] SuperHero superHero)
        {
            try
            {
                if (superHero == null || superHero.Id != id)
                {
                    return BadRequest("Invalid superhero data.");
                }

                var existingSuperHero = superHeroService.GetSuperHeroById(id);
                if (existingSuperHero == null)
                {
                    return NotFound($"Superhero with Id {id} not found.");
                }

                superHeroService.UpdateSuperHero(id, superHero);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSuperHero(int id)
        {
            try
            {
                var existingSuperhero = superHeroService.GetSuperHeroById(id);
                if (existingSuperhero == null)
                {
                    return NotFound($"Superhero with Id {id} not found.");
                }

                superHeroService.DeleteSuperHero(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
