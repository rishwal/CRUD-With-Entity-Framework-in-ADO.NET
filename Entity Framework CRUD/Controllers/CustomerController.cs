using Entity_Framework_CRUD.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entity_Framework_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            List<CustomerDTO> customers = _context.Customers.ToList();

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            CustomerDTO customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            return customer != null ? Ok(customer) : NotFound($"Customer with Id : {id} Not Found !");

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                //List<CustomerDTO> customers = _context.Customers.ToList();
                //if (customers.Any())
                //{
                //    customer.Id = customers.Max(c => c.Id) + 1;
                //}
                //else
                //{
                //    customer.Id = 1;
                //}

                _context.Customers.Add(customer);

                _context.SaveChanges();

                return Ok("New customer added successfully !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occuured in server!");
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
