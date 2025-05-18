using ET.Application.Interfaces;
using ET.Application.Views;
using Microsoft.AspNetCore.Mvc;

namespace ET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryBudgetController : ControllerBase
    {
        private readonly ICategoryBudgetService _categoryBudgetService;

        public CategoryBudgetController(ICategoryBudgetService categoryBudgetService)
        {
            _categoryBudgetService = categoryBudgetService;
        }

       
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CategoryBudgetDTO>>> GetBudgetsByUserId(int userId)
        {
            var budgets = await _categoryBudgetService.GetBudgetsByUserIdAsync(userId);
            return Ok(budgets);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryBudgetDTO>> GetBudgetById(int id)
        {
            var budget = await _categoryBudgetService.GetBudgetByIdAsync(id);
            if (budget == null)
                return NotFound();

            return Ok(budget);
        }

       
        [HttpPost]
        public async Task<ActionResult<CategoryBudgetDTO>> CreateBudget([FromBody] CreateCategoryBudgetDTO createDto)
        {
            var createdBudget = await _categoryBudgetService.CreateBudgetAsync(createDto);
            return CreatedAtAction(nameof(GetBudgetById), new { id = createdBudget.Id }, createdBudget);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryBudgetDTO>> UpdateBudget(int id, [FromBody] UpdateCategoryBudgetDTO updateDto)
        {
            try
            {
                var updatedBudget = await _categoryBudgetService.UpdateBudgetAsync(id, updateDto);
                return Ok(updatedBudget);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudget(int id)
        {
            var deleted = await _categoryBudgetService.DeleteBudgetAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
