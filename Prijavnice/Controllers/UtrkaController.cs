using Microsoft.AspNetCore.Mvc;
using Prijavnice.Data;
using Prijavnice.Models;

namespace Prijavnice.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtrkaController : ControllerBase
    {


        private readonly PrijavniceContext _context;



        public UtrkaController(PrijavniceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Utrke);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return Ok(_context.Utrke.Find(sifra));
        }



        [HttpPost]
        public IActionResult Post(Utrka utrka)
        {
            _context.Utrke.Add(utrka);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, utrka);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Utrka utrka)
        {
            var utrkaBaza = _context.Utrke.Find(sifra);


            utrkaBaza.Datum = utrka.Datum;
            utrkaBaza.Mjesto = utrka.Mjesto;
            utrkaBaza.Naziv = utrka.Naziv;
            
            

            _context.Utrke.Update(utrkaBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });

        }



        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var utrkaBaza = _context.Utrke.Find(sifra);

            _context.Utrke.Remove(utrkaBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });

        }
        
    
    }
}
