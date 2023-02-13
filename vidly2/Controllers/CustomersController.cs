using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly2.Models;
using vidly2.ViewModels;

namespace vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //this method is to dispose dbcontext
        }

        public ActionResult Edit(int id)
        {
            var customerFullRow = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerFullRow == null)
                return HttpNotFound();

            var ViewModel = new CustomerMembershipTypeViewModel
            {
                Customer = customerFullRow,
                MembershipTypes = _context.MembershipTypes.ToList() 
                 
            };

            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerMembershipTypeViewModel
                {
                    Customer = Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);
            }
            if(Customer.Id==0)
                _context.Customers.Add(Customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == Customer.Id);

                customerInDb.Name = Customer.Name;
                customerInDb.Birthdate = Customer.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = Customer.MembershipTypeId;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerMembershipTypeViewModel
            {
                Customer = new Customer() ,
                MembershipTypes = membershipTypes 
            };

            return View("CustomerForm",viewModel);
        } 

        public ActionResult Index()
        {
            //var customers = GetCumstomers();
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);

        }

       public ActionResult Details(int id)
        {
            //var custName = GetCumstomers().SingleOrDefault(c => c.Id == id);
            var custNameTotalRow = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (custNameTotalRow == null)
                return HttpNotFound();


            // return Content(String.Format("{0}Membership Type:{1}BirtDate:{2}",custName.Name,custName.MembershipType,custName.Birthdate));
            return View(custNameTotalRow);
           
        }
        //private List<Customer> GetCumstomers()
        //{
        //    return new List<Customer>
        //    {
        //       new Customer { Id = 1, Name = "Mary Williams" },
        //       new Customer { Id = 2, Name = "John Smith" }
        //    };
        //}

    }
}