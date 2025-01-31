﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactMAnager.Data;
using ContactMAnager.Models;

namespace Contact.Controllers
{
	public class ContactItemsController : Controller
	{
		private readonly ApplicationDbContext _context;


		private readonly IWebHostEnvironment _webHostEnvironment;

		public ContactItemsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

        // GET: ContactItems
        public async Task<IActionResult> Index(string searchString)
        {

            var contacts = await _context.contactitems.Where(
                c => string.IsNullOrEmpty(searchString)||
				(c.FirstName.Contains(searchString))||
                 (c.MiddleName.Contains(searchString))||
                 (c.LastName.Contains(searchString)))
                 .OrderBy(c => c.FirstName)
                 .ThenBy(c => c.MiddleName)
                 .ThenBy(c => c.LastName)
                 .ToListAsync();

            var count = await _context.contactitems.CountAsync();

            ViewBag.ContactCount = count; // Store count in ViewBag

            return View(contacts);
        }

        // GET: ContactItems/Details/5
        public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contactItem = await _context.contactitems
				.FirstOrDefaultAsync(m => m.Id == id);
			if (contactItem == null)
			{
				return NotFound();
			}

			return View(contactItem);
		}

		// GET: ContactItems/Create
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PhoneNumber, MiddleName, LastName,FirstName,ImageFile,ImagePath,Email,Nickname,BirthDay,Address,Notes")]
 contactitem contactItem)
		{

			if (contactItem.ImageFile != null)
			{
				Console.WriteLine($"Received file: {contactItem.ImageFile.FileName}");
			}
			else
			{
				Console.WriteLine("No file received.");
			}

			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors);
				foreach (var error in errors)
				{
					Console.WriteLine(error.ErrorMessage); // Log or show these to the user
				}
				return View(contactItem);
			}


			// Check if an image is uploaded
			if (contactItem.ImageFile != null && contactItem.ImageFile.Length > 0)
			{
				// Define the path to save the image
				var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
				if (!Directory.Exists(imagesPath))
				{
					Directory.CreateDirectory(imagesPath); // Ensure directory exists
				}

				var filePath = Path.Combine(imagesPath, contactItem.ImageFile.FileName);

				// Save the image file to the specified path
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await contactItem.ImageFile.CopyToAsync(stream);
				}

				// Save the file path to the database
				contactItem.ImagePath = "/images/" + contactItem.ImageFile.FileName;
			}

			// Add contactItem to the context and save
			_context.Add(contactItem);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET: ContactItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contactItem = await _context.contactitems.FindAsync(id);
			if (contactItem == null)
			{
				return NotFound();
			}
			return View(contactItem);
		}

	
				// POST: ContactItems/Edit/5
				// To protect from overposting attacks, enable the specific properties you want to bind to.
				// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
				[HttpPost]
				[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName, MiddleName, LastName, PhoneNumber,Email,ImagePath, ImageFile, Nickname,BirthDay,Address,Notes")] contactitem contactItem)
		{
			if (id != contactItem.Id)
			{
				return NotFound();
			}

			// Check if image file is provided
			if (contactItem.ImageFile != null)
			{
				// Path where image will be stored
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + contactItem.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// Save the file
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await contactItem.ImageFile.CopyToAsync(fileStream);
				}

				// Set the image path to save it in database
				contactItem.ImagePath = "/images/" + uniqueFileName;
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(contactItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ContactItemExists(contactItem.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(contactItem);
		}


		// GET: ContactItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var contactItem = await _context.contactitems
				.FirstOrDefaultAsync(m => m.Id == id);
			if (contactItem == null)
			{
				return NotFound();
			}

			return View(contactItem);
		}


		// POST: ContactItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var contactItem = await _context.contactitems.FindAsync(id);
			if (contactItem != null)
			{
				_context.contactitems.Remove(contactItem);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ContactItemExists(int id)
		{
			return _context.contactitems.Any(e => e.Id == id);
		}
	}
}