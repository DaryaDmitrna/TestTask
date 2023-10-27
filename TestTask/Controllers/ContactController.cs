using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactsContext _context;
        public ContactController(ContactsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Contact> ListContacts = _context.Contact.ToList();
            return View(ListContacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,DateOfCreation,DateOfChange")] Contact contact)
        {
            if (_context.Contact.Any(c => c.Email == contact.Email))
            {
                ModelState.AddModelError(nameof(contact.Email), "Такой Email уже занят");
            }
            if (ModelState.IsValid)
            {
                contact.DateOfCreation = DateTime.Now;
                contact.DateOfChange = contact.DateOfCreation;
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,DateOfCreation,DateOfChange")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }
            if (_context.Contact.Where(c => c.Email == contact.Email && c.Id != contact.Id).Any())
            {
                ModelState.AddModelError(nameof(contact.Email), "Такой Email уже занят");
            }
            if (ModelState.IsValid)
            {
                contact.DateOfChange = DateTime.Now;
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contact == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
