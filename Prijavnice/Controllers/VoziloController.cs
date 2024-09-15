using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prijavnice.Data;

namespace Prijavnice.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VoziloController : ControllerBase
    {
        private readonly PrijavniceContext _context;
    }


    public VoziloController(PrijavniceContext context)
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
    public IActionResult Post(Vozila vozilo)
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
        var smjerBaza = _context.Vozila.Find(sifra);

        
        smjerBaza.Marka = vozilo.Naziv;
        smjerBaza.Model = vozilo.Trajanje;
        smjerBaza.Snaga = vozilo.Cijena;
        smjerBaza.Pogon = vozilo.IzvodiSeOd;
        

        _context.Vozila.Update(smjerBaza);
        _context.SaveChanges();

        return Ok(new { poruka = "Uspješno promjenjeno" });

    }



    [HttpDelete]
    [Route("{sifra:int}")]
    [Produces("application/json")]
    public IActionResult Delete(int sifra)
    {
        var smjerBaza = _context.Vozila.Find(sifra);

        _context.Vozila.Remove(smjerBaza);
        _context.SaveChanges();

        return Ok(new { poruka = "Uspješno obrisano" });

    }




}
