using Microsoft.AspNetCore.Mvc;
using Prijavnice.Data;
using Prijavnice.Models;

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
            return Ok(_context.Utrka);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return Ok(_context.Utrka.Find(sifra));
        }



        [HttpPost]
        public IActionResult Post(Utrka utrka)
        {
            _context.Utrka.Add(utrka);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, utrka);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Utrka utrka)
        {
            var utrkaBaza = _context.Utrka.Find(sifra);


            utrkaBaza.Datum = utrka.datum;
            utrkaBaza.Mjesto = utrka.mjesto;
            utrkaBaza.Naziv = utrka.naziv;
            
            

            _context.Utrka.Update(utrkaBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });

        }



        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var utrkaBaza = _context.Utrka.Find(sifra);

            _context.Utrka.Remove(utrkaBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });

        }
        
    
    }
}
