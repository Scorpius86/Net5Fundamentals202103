using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Repositories;
using Entities = Net5.Fundamentals.AspNet.Data.Entities;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        [BindProperty]
        public Entities.Customer Customer { get; set; }

        public EditModel(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _customerRepository.Get(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Customer = _customerRepository.Update(Customer);
            }
            catch (Exception ex)
            {
                if (!_customerRepository.Exists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
            

            return RedirectToPage("./Index");
        }
    }
}
