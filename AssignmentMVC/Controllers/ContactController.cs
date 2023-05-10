using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Models;
using AssignmentMVC.ViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AssignmentMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext _contactContext;

        public ContactController(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        [HttpPost]
        public async Task<IActionResult> ContactsIndexAsync(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new ContactModel
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Company = model.Company,
                    Comment = model.Comment,
                    Timestamp = DateTime.Now
                };

                _contactContext.Contacts.Add(contact);
                await _contactContext.SaveChangesAsync();

                return RedirectToAction("ThankYou");
            }
            else
            {
                return View("ContactsIndex", model);
            }
        }

        public IActionResult ContactsIndexAsync()
        {
            return View();
        }


        public IActionResult ThankYou()
        {
            return View();
        }
    }
}

