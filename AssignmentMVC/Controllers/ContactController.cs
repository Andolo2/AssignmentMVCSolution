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

        //[HttpPost]
        public IActionResult ContactsIndex(ContactViewModel model)
        {
            System.Diagnostics.Debug.WriteLine($"Current DbContext: {_contactContext.GetType().Name}");
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
                _contactContext.SaveChanges();

                return RedirectToAction("ThankYou");
            }
            else
            {
                return View("ContactsIndex", model);
            }




  
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}

