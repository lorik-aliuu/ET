using ET.Application.Interfaces;
using ET.Application.Views;
using Microsoft.AspNetCore.Mvc;

namespace ET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }


        [HttpPost("{userId:int}/{categoryId:int}")]
        public async Task<IActionResult> CreateExpense(int userId, int categoryId, [FromBody] CreateExpenseDTO dto)
        {
            // Check if the expense can be added without exceeding budgets
            var canAdd = await _expenseService.CanAddExpenseAsync(userId, categoryId, dto.Amount);
            if (!canAdd)
            {
                return BadRequest("Cannot add expense: Budget limit exceeded (category or overall).");
            }

            var result = await _expenseService.CreateExpenseAsync(userId, categoryId, dto);
            return CreatedAtAction(nameof(GetExpenseById), new { id = result.Id }, result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var result = await _expenseService.GetAllExpensesAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var result = await _expenseService.GetExpenseByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

       
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] UpdateExpenseDTO dto)
        {
            var result = await _expenseService.UpdateExpenseAsync(id, dto);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var success = await _expenseService.DeleteExpenseAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}

