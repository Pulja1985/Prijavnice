using Microsoft.AspNetCore.Mvc;
using Prijavnice.Data;
using Prijavnice.Models;

namespace Prijavnice.Controllers
{
    public class UtrkeController
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
            public IActionResult Post(Utrke utrka)
            {
                _context.Utrke.Add(utrka);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, utrka);
            }

            [HttpPut]
            [Route("{sifra:int}")]
            [Produces("application/json")]
            public IActionResult Put(int sifra, Utrke utrka)
            {
                var utrkeBaza = _context.Utrke.Find(sifra);



                utrkeBaza.Datum = utrka.Datum;
                utrkeBaza.Mjesto = utrka.Mjesto;
                utrkeBaza.Naziv = utrka.Naziv;

                _context.Utrke.Update(utrkeBaza);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });

            }



            [HttpDelete]
            [Route("{sifra:int}")]
            [Produces("application/json")]
            public IActionResult Delete(int sifra)
            {
                var utrkeBaza = _context.Utrke.Find(sifra);

                _context.Utrke.Remove(utrkeBaza);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno obrisano" });

            }

        }
}    }
