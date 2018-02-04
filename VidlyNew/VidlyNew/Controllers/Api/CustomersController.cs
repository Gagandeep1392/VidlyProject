using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.DTO;
using VidlyNew.Models;
using System.Data.Entity;

namespace VidlyNew.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext m_dbContext;

        public CustomersController()
        {
            m_dbContext = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomer(string query = null)
        {
            var customersQuery = m_dbContext.Customer
                .Include(c => c.MembershipType);

            if (!string.IsNullOrEmpty(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customersDto = customersQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
        }

        //// GET /api/customers/1
        //public CustomerDto GetCustomer(int id)
        //{
        //    var customer = m_dbContext.Customer.SingleOrDefault(c => c.Id == id);

        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map<Customer,CustomerDto>(customer);
        //}

        // GET /api/customers/1

        // GET /api/customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = m_dbContext.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            m_dbContext.Customer.Add(customer);
            m_dbContext.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id , CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = m_dbContext.Customer.SingleOrDefault(c => c.Id == customerDto.Id);
            if (customerDb == null)
                return NotFound();

            var cus = Mapper.Map<CustomerDto, Customer>(customerDto, customerDb); 

            m_dbContext.SaveChanges();

            return Ok(cus);
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = m_dbContext.Customer.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                return NotFound();

            m_dbContext.Customer.Remove(customerDb);
            m_dbContext.SaveChanges();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerDb));
        }

    }
}
