using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly LUCKYContext _context;
        public ContactoController(LUCKYContext context)
        {
            _context = context;
        }

        // GET: api/<ContactoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listcontactos =  await _context.Contactos.ToListAsync();
                return Ok(listcontactos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContactoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contacto contacto)
        {
            try
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return Ok(contacto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<ContactoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contacto contacto)
        {
            try
            {
                if(id != contacto.Id)
                {
                    return NotFound();
                }
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Contacto Actualizado"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contacto = await _context.Contactos.FindAsync(id);
                if (contacto == null)
                {
                    return NotFound();
                }
                _context.Contactos.Remove(contacto);
                await _context.SaveChangesAsync();
                return Ok(new { message="Contacto Eliminado"});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
