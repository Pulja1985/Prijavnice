using Prijavnice.Data;
using Prijavnice.Models;
using Microsoft.AspNetCore.Mvc;


namespace Prijavnice.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PrijavniceController : ControllerBase
    {
        
        
        private readonly PrijavniceContext _context;

        
        
        public PrijavniceController(PrijavniceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Vozila);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return Ok(_context.Vozila.Find(sifra));
        }



        [HttpPost]
        public IActionResult Post(Vozilo vozilo)
        {
            _context.Vozila.Add(vozilo);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, vozilo);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Vozilo vozilo) 
        {
            var voziloBaza = _context.vozilo.Find(sifra);

            
            voziloBaza.Marka = vozilo.marka;
            voziloBaza.Model = vozilo.model;
            voziloBaza.Snaga = vozilo.snaga;
            voziloBaza.Pogon = vozilo.pogon;
            voziloBaza.Vozaci_sifra = vozilo.vozaci_sifra;

            _context.Vozila.Update(voziloBaza);
            _context.SaveChanges();

            return Ok(new {poruka = "Uspješno promjenjeno"});
        
        }



        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var voziloBaza = _context.Vozila.Find(sifra);

            _context.Vozila.Remove(voziloBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });

        }


    }
}
