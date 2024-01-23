using Microsoft.AspNetCore.Mvc;
using WebMVC01.Data;
using WebMVC01.Models;

namespace WebMVC01.Controllers
{
    public class CustomersController : Controller
    {
        private readonly WebMVC01Context _context;

        public CustomersController(WebMVC01Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Customer> Customers = _context.Customers.ToList();
            return View(Customers);
        }

        //Get: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // CREATE
        [HttpPost]
        public IActionResult Create([Bind("CustomerId,FirstName,LastName,Year,SSN")] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
		public IActionResult Details(int? id)
		{
			Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
			return View(customer);
		}

        // Edit Customer
		public IActionResult Edit(int? id)
		{
			Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
			return View(customer);
		}

		// POST: Edit Customer
		[HttpPost]
		public IActionResult Edit([Bind("CustomerId,FirstName,LastName,Year,SSN")] Customer customer)
		{
			_context.Customers.Update(customer);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		// GET: Delete Customer
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var customer = _context.Customers.FirstOrDefault(m => m.CustomerId == id);

            if(customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Delete Customer
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(x => x.CustomerId == id);
        }
	}

}