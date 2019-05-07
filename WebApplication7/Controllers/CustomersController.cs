using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using System.Data.Entity;
using WebApplication7.ViewModel;

namespace WebApplication7.Controllers
{
    [RequireHttps]
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();    
        }
        // GET: Customers

        public ActionResult Index()
        {
            List<Customer> Customers = dbContext.Customers.Include(m=>m.MembershipType).ToList();
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m => m.MembershipType).SingleOrDefault(a => a.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer{ID=1,Name="Vivek", DateOfBirth=Convert.ToDateTime("01-01-2000")},
                new Customer{ID=2,Name="Saurav", DateOfBirth=Convert.ToDateTime("02-01-2000")},
                new Customer{ID=3, Name="Vivek Saurav", DateOfBirth=Convert.ToDateTime("03-01-2000")}
            };
            return customers;
        }

        [HttpGet]
        public ActionResult Create()
        {
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }        
                CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
                Customer Customer = new Customer();
                var membershipTypes = dbContext.MembershipTypes.ToList();
                viewModel.Customer = Customer;
                viewModel.MembershipTypes = membershipTypes;
                return View(viewModel);            
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.ID == Id);
            var memtypes = dbContext.MembershipTypes.ToList();
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel()
            {
                Customer = customer,
                MembershipTypes = memtypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customertbl = dbContext.Customers.SingleOrDefault(c=>c.ID==customer.ID);
            if (customertbl == null)
            {
                return HttpNotFound();
            }
            else
            {
                customertbl.Name = customer.Name;
                customertbl.DateOfBirth = customer.DateOfBirth;
                customertbl.MembershipTypeID = customer.MembershipTypeID;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Customers");
        }
    }
}