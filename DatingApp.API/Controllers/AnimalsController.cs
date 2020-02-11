using DatingApp.Api.Data;
using DatingApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//using ResponseFormattingSample.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
    private readonly DataContext _context;
        public AnimalsController(DataContext context)
        {
          _context = context;  
          _context.Database.EnsureCreated();          
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
    //   _context.Animals.Add(new Animal { Id = 1, Name = "Simba", DateOfBirth = DateTime.Now });
    //    _context.Animals.Add(new Animal { Id = 4, Name = "Tobii", DateOfBirth = DateTime.Now });
    //     _context.Animals.Add(new Animal { Id = 5, Name = "Maxii", DateOfBirth = DateTime.Now });
    //      _context.Animals.Add(new Animal { Id = 41, Name = "Swara", DateOfBirth = DateTime.Now });
    //   _context.SaveChanges();

      var ans = await _context.Animals.ToListAsync();            
            return Ok(ans);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ans = await _context.Animals.FirstOrDefaultAsync( x => x.Id == id);
            return Ok(ans);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
