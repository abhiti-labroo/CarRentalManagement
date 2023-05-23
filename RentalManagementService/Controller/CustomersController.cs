using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services;
using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    // GET: api/customers
    [HttpGet]
    public ActionResult<IEnumerable<CustomerRDto>> GetAllCustomers()
    {
        var customers = _customerService.GetAllCustomers();
        return Ok(customers);
    }
    // GET: api/customers/{id}
    [HttpGet("{id}")]
    public ActionResult<CustomerRDto> GetCustomer(int id)
    {
        var customer = _customerService.GetCustomer(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
    // POST: api/customers
    [HttpPost]
    public ActionResult<CustomerRDto> AddCustomer(CustomerRDto customer)
    {
        _customerService.AddCustomer(customer);

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.CusId }, customer);
    }
    // PUT: api/customers/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, CustomerRDto customer)
    {
        if (id != customer.CusId)
        {
            return BadRequest();
        }
        if (!_customerService.CustomerExists(id))
        {
            return NotFound();
        }
        _customerService.UpdateCustomer(customer);
        return NoContent();
    }
    // DELETE: api/customers/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        if (!_customerService.CustomerExists(id))
        {
            return NotFound();
        }
        _customerService.DeleteCustomer(id);
        return NoContent();
    }
}

