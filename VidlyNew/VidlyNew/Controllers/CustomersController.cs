using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext m_dbContext;

        public CustomersController()
        {
            m_dbContext = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var objCustomers = GetCustomers();

            //var objCustomers = m_dbContext.Customer.Include(c => c.MembershipType).ToList();
            //return View(objCustomers);

            return View();
        }

      
        public ActionResult Details(int id)
        {
            var customerList = m_dbContext.Customer.Include(c => c.MembershipType).ToList();
            var customer = customerList.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = m_dbContext.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if(customer.Id == 0)
                m_dbContext.Customer.Add(customer);
            else
            {
                var customerDb = m_dbContext.Customer.Single(c => c.Id == customer.Id);

                customerDb.Id = customer.Id;
                customerDb.Name = customer.Name;
                customerDb.Birthdate = customer.Birthdate;
                customerDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerDb.MembershipTypeId = customer.MembershipTypeId;

            }

            m_dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var listMemberShipType = m_dbContext.MembershipType.ToList();
            var newCustomerviewModel = new CustomerFormViewModel
            {
                MembershipType = listMemberShipType
            };
            return View("CustomerForm", newCustomerviewModel);
        }

        public ActionResult Edit(int Id)
        {
           // throw new Exception();

            var customerDb = m_dbContext.Customer.SingleOrDefault(c => c.Id == Id);

            if (customerDb == null)
                return HttpNotFound();

            var newCustomerviewModel = new CustomerFormViewModel
            {
                Customer = customerDb,
                MembershipType = m_dbContext.MembershipType.ToList()
            };

            return View("CustomerForm", newCustomerviewModel);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1,Name = "Gagandeep Kaur" },
                new Customer { Id = 2, Name = "Sandeep Kaur" }
            };
        }


    }
}