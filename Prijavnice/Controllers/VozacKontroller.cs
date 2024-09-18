using Microsoft.AspNetCore.Mvc;
using Prijavnice.Data;
using Prijavnice.Models;

namespace Prijavnice.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VozacController : ControllerBase
    {


        private readonly PrijavniceContext _context;



        public VozacController(PrijavniceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Vozaci);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return Ok(_context.Vozaci.Find(sifra));
        }



        [HttpPost]
        public IActionResult Post(Vozac vozaci)
        {
            _context.Vozaci.Add(vozaci);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, vozaci);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Vozac vozac)
        {
            var vozacBaza = _context.Vozaci.Find(sifra);


            
            vozacBaza.Ime = vozac.Ime;
            vozacBaza.Prezime = vozac.Prezime;
            vozacBaza.Oib = vozac.Oib;

            _context.Vozaci.Update(vozacBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });

        }



        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var vozacBaza = _context.Vozaci.Find(sifra);

            _context.Vozaci.Remove(vozacBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });

        }



        
    
    }
}
