using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Data;
using Restaurant_manager_x_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_manager_x_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DishController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dish
        //getall
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dish/5
        //getone
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        // POST: api/Dish
        // Add dish
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDish", new { id = dish.id }, dish);
        }

        // PUT: api/Dish/5
        // Update dish
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(int id, Dish dish)
        {
            if (id != dish.id)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Dish/5
        // Delete Dish
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.id == id);
        }

         // Add an ingredient to a dish
        [HttpPost("{id}/add-ingredient")]
        public async Task<IActionResult> AddIngredient(int id, [FromBody] string ingredient)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            dish.AddIngredient(ingredient);
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Remove an ingredient from a dish
        [HttpPost("{id}/remove-ingredient")]
        public async Task<IActionResult> RemoveIngredient(int id, [FromBody] string ingredient)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            dish.RemoveIngredient(ingredient);
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Check if a dish contains a specific ingredient
        [HttpGet("{id}/contains-ingredient/{ingredient}")]
        public async Task<ActionResult<bool>> ContainsIngredient(int id, string ingredient)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            return dish.ContainsIngredient(ingredient);
        }
    }
}
