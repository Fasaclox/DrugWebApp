using DrugWebApp.Context;
using DrugWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugWebApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : Controller
    {
        
        private readonly DrugContext _drugContext;

        public DrugController(DrugContext drugContext) => _drugContext = drugContext;
        [HttpGet]
        public async Task<IEnumerable<Drug>> GetAsync()
         => await _drugContext.Drugs.ToListAsync();

        //Get Operation 
        [HttpGet("id")]
        [ActionName(nameof(GetbyIdAsync))]
        [ProducesResponseType(typeof(Drug), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetbyIdAsync(int id)
        {
            var drug = await _drugContext.Drugs.FindAsync(id);
            return drug == null ? NotFound() : Ok(drug);
        }
        //Post Operation 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Drug drug)
        {
            await _drugContext.Drugs.AddAsync(drug);
            await _drugContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetbyIdAsync), new { id = drug.DrugId }, drug);
        }
        //Put Operation
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Drug drug)
        {
            if (id != drug.DrugId) return BadRequest();
            _drugContext.Entry(drug).State = EntityState.Modified;
            await _drugContext.SaveChangesAsync();
            return NoContent();
        }
        //Delete Operation 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var DrugToDelete = await _drugContext.Drugs.FindAsync(id);
            if (DrugToDelete == null) return NotFound();

            _drugContext.Drugs.Remove(DrugToDelete);
            await _drugContext.SaveChangesAsync();

            return NoContent();

        }

    }



}
