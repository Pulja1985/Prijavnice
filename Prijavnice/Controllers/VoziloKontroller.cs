using Microsoft.AspNetCore.Mvc;
using Prijavnice.Data;
using Prijavnice.Models;

namespace Prijavnice.Controllers
{
    public class VoziloKontroller
    {

        [ApiController]
        [Route("api/v1/[controller]")]
        public class VoziloController : ControllerBase
        {


            private readonly PrijavniceContext _context;



            public VoziloController(PrijavniceContext context)
            {
                _context = context;
            }


            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_context.Vozilo);
            }

            [HttpGet]
            [Route("{sifra:int}")]
            public IActionResult GetBySifra(int sifra)
            {
                return Ok(_context.Vozilo.Find(sifra));
            }



            [HttpPost]
            public IActionResult Post(Vozilo vozila)
            {
                _context.Vozilo.Add(vozila);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, vozila);
            }

            [HttpPut]
            [Route("{sifra:int}")]
            [Produces("application/json")]
            public IActionResult Put(int sifra, Vozilo vozila)
            {
                var voziloBaza = _context.Vozilo.Find(sifra);



                voziloBaza.Marka = vozila.Marka;
                voziloBaza.Model = vozila.Model;
                voziloBaza.Snaga = vozila.Snaga;
                voziloBaza.Pogon = vozila.Pogon;

                _context.Vozilo.Update(voziloBaza);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });

            }



            [HttpDelete]
            [Route("{sifra:int}")]
            [Produces("application/json")]
            public IActionResult Delete(int sifra)
            {
                var voziloBaza = _context.Vozilo.Find(sifra);

                _context.Vozilo.Remove(voziloBaza);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno obrisano" });

            }



        }
}   }

