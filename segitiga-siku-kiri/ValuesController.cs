using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly KalbeContext _context;

        public ValuesController(KalbeContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok(FindAll());
        }

        [HttpGet()]
        [Route("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] PagingParams Paging)
        {
            //var data = _context.Customer
            //            .OrderBy(ss => ss.TxtCustomerName)
            //            .Skip((Paging.PageNumber - 1) * Paging.PageSize)
            //            .Take(Paging.PageSize)
            //            .ToList();
            var data = GetCustomers(Paging);

            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));            
            
            return Ok(data);
        }

        public PagedList<Customer> GetCustomers(PagingParams Paging)
        {
            var data = PagedList<Customer>.ToPagedList(_context.Customer.ToList().OrderBy(ss => ss.TxtCustomerName), Paging.PageNumber, Paging.PageSize);
            return data;
        }

        public List<Customer> FindAll()
        {
            var data = _context.Customer.ToList();

            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _context.Customer.Where(ss => ss.IntCustomerId == id).FirstOrDefault();
            return Ok(data);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerPost Model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Customer toInsert = new Customer();
                    toInsert.TxtCustomerName = Model.Name;
                    toInsert.TxtCustomerAddress = Model.Address;

                    _context.Customer.Add(toInsert);
                    _context.SaveChanges();

                    return Ok("Data has been save");
                }
                catch (Exception)
                {
                    return Ok("Data hasn't been save");
                    throw;
                }
            }


            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerPost Model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Customer toUpdate = _context.Customer.Find(id);
                    toUpdate.TxtCustomerName = Model.Name;
                    toUpdate.TxtCustomerAddress = Model.Address;

                    _context.SaveChanges();

                    return Ok("Data has been update");
                }
                catch (Exception)
                {
                    return Ok("Data hasn't been update");
                    throw;
                }
                                
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
