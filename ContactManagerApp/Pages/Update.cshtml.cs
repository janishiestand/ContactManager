using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApp.Pages
{
	public class UpdateModel : PageModel
    {
        private readonly IContactRepository _db;

        public UpdateModel(IContactRepository db)
        {
            _db = db;
        }

        [BindProperty]
        public Contact? Cnt { get; set; }

        public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
        {
            var cntToUpdate = await _db.FindAsync(id, cancellationToken);

            if (cntToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Contact>(
                cntToUpdate, "Cnt",
                c => c.FirstName,  c => c.LastName, c => c.PhoneNumber, c => c.Birthday))
            {
                await _db.SaveChangesAsync(cancellationToken);
                return Redirect("../Index");
            }
            return Page();
        }

    }
}
