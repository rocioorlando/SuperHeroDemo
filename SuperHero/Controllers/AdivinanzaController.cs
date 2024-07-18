using Microsoft.AspNetCore.Mvc;
using SuperHeroWeb.Business;
using SuperHeroWeb.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdivinanzaController : ControllerBase
    {
        private readonly IAdivinanzaService adivinanzaService;
        public AdivinanzaController(IAdivinanzaService adivinanzaService)
        {
            this.adivinanzaService = adivinanzaService;
        }

        // POST api/<AdivinanzaController>
        [HttpPost]
        public IActionResult Post([FromBody] int numeroUsuario)
        {
            var mensaje = adivinanzaService.ValidarNumero(numeroUsuario);
            return Ok(mensaje);
        }

        [HttpPost]
        [Route("PostReiniciar")]
        public IActionResult PostReiniciar()
        {
            adivinanzaService.ReiniciarJuegoPorQueAlPutoSeLeOcurre();
            return Ok("Juego reiniciado");
        }

    }
}
