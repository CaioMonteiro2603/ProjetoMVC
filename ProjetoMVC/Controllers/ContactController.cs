using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return NotFound();
            }

            return View(); 
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            var contactBank = _context.Contacts.Find(contact.Id);

            contactBank.Name = contact.Name;
            contactBank.Telephone = contact.Telephone;
            contactBank.Active = contact.Active;
            
            _context.Contacts.Update(contactBank);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contact); 
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact); 
        }

        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            var contactBank = _context.Contacts.Find(contact.Id);

            _context.Contacts.Remove(contactBank);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
