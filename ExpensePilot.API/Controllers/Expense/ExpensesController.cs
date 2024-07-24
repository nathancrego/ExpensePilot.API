using ExpensePilot.API.Models.Domain.Expense;
using ExpensePilot.API.Models.DTO.Expense;
using ExpensePilot.API.Repositories.Interface.Expense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensePilot.API.Controllers.Expense
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepository expensesRepository;

        public ExpensesController(IExpensesRepository expensesRepository)
        {
            this.expensesRepository = expensesRepository;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> CreateExpense([FromForm] InvoiceReceiptUploadDto receiptUploadDto, [FromForm] AddExpensesDto addExpenses)
        {
            if (receiptUploadDto.File == null || addExpenses == null)
            {
                return BadRequest("Please upload the Invoice receipt and fill the required details in the Expense Form");
            }
            var expense = new Expenses
            {
                ExpenseName = addExpenses.ExpenseName,
                ExpenseDescription = addExpenses.ExpenseDescription,
                ExpenseCategoryID = addExpenses.ExpenseCategoryID,
                InvoiceNumber = addExpenses.InvoiceNumber,
                InvoiceVendorName = addExpenses.InvoiceVendorName,
                TotalAmount = addExpenses.TotalAmount,
                UserID = addExpenses.UserID
            };
            expense = await expensesRepository.CreateAsync(expense, receiptUploadDto);
            var response = new ExpensesDto
            {
                ExpenseID = expense.ExpenseID,
                ExpenseName = expense.ExpenseName,
                ExpenseDescription = expense.ExpenseDescription,
                ExpenseCategoryID = expense.ExpenseCategoryID,
                InvoiceNumber = expense.InvoiceNumber,
                InvoiceVendorName = expense.InvoiceVendorName,
                TotalAmount = expense.TotalAmount,
                UserID = expense.UserID
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await expensesRepository.GetAllAsync();

            var response = new List<ExpensesDto>();
            foreach(var expense in expenses)
            {
                response.Add(new ExpensesDto
                {
                    ExpenseID = expense.ExpenseID,
                    ExpenseName = expense.ExpenseName,
                    ExpenseDescription = expense.ExpenseDescription,
                    ExpenseCategoryID = expense.ExpenseCategoryID,
                    InvoiceNumber = expense.InvoiceNumber,
                    InvoiceVendorName = expense.InvoiceVendorName,
                    TotalAmount = expense.TotalAmount,
                    UserID = expense.UserID
                });
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] int id, [FromForm] InvoiceReceiptUploadDto receiptUploadDto, [FromForm] EditExpensesDto editExpenses)
        {
            // Validate the input DTOs
            if (receiptUploadDto == null || editExpenses == null)
            {
                return BadRequest("Invalid request payload.");
            }

            // Create an Expenses object with the new data
            var updateExpense = new Expenses
            {
                ExpenseID = id, // Ensure the ID is correctly set
                ExpenseName = editExpenses.ExpenseName,
                ExpenseDescription = editExpenses.ExpenseDescription,
                ExpenseCategoryID = editExpenses.ExpenseCategoryID,
                InvoiceNumber = editExpenses.InvoiceNumber,
                InvoiceVendorName = editExpenses.InvoiceVendorName,
                TotalAmount = editExpenses.TotalAmount,
                UserID = editExpenses.UserID
            };

            // Call the update method
            var updatedExpense = await expensesRepository.UpdateAsync(updateExpense, receiptUploadDto);

            // Check if the update was successful
            if (updatedExpense == null)
            {
                return NotFound("Expense or InvoiceReceipt not found.");
            }

            // Create a response DTO
            var response = new ExpensesDto
            {
                ExpenseID = updatedExpense.ExpenseID,
                ExpenseName = updatedExpense.ExpenseName,
                ExpenseDescription = updatedExpense.ExpenseDescription,
                ExpenseCategoryID = updatedExpense.ExpenseCategoryID,
                InvoiceNumber = updatedExpense.InvoiceNumber,
                InvoiceVendorName = updatedExpense.InvoiceVendorName,
                TotalAmount = updatedExpense.TotalAmount,
                InvoiceReceiptID = updatedExpense.InvoiceReceiptID,
                UserID = updatedExpense.UserID
            };

            // Return the response
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {
            var deleteExpense = await expensesRepository.DeleteAsync(id);
            if(deleteExpense == null)
            {
                return NotFound();
            }
            var response = new ExpensesDto
            {
                ExpenseID = deleteExpense.ExpenseID,
                ExpenseName = deleteExpense.ExpenseName,
                ExpenseDescription = deleteExpense.ExpenseDescription,
                ExpenseCategoryID = deleteExpense.ExpenseCategoryID,
                InvoiceNumber = deleteExpense.InvoiceNumber,
                InvoiceVendorName = deleteExpense.InvoiceVendorName,
                TotalAmount = deleteExpense.TotalAmount,
                UserID = deleteExpense.UserID
            };
            return Ok(response);
        }
    }
}
