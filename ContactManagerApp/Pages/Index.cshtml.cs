using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFDataAccessLibrary.DataAccess;
using System.Text.Json;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary.Interfaces;
using ContactManagerApp;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactManagerApp.Pages;

public class IndexModel : PageModel
{
    private readonly IContactRepository _db;

    public IList<Contact> Contacts = new List<Contact>();

    [BindProperty, Required]
    public string? FirstName { get; set; }

    [BindProperty, Required]
    public string? LastName { get; set; }

    [BindProperty, Required]
    public string? PhoneNumber { get; set; }

    [BindProperty, Required]
    public string? Birthday { get; set; }
    /*
    [BindProperty, Required, DisplayName()]
    public List<Email> EmailAddresses { get; set; } = new List<Email>();

    [BindProperty, Required, DisplayName()]
    public List<Address> Addresses { get; set; } = new List<Address>();
    */

    public IndexModel(IContactRepository db)
    {
        _db = db;
    }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Contacts = await _db.ToListAsync(cancellationToken);
 
            Contacts = await _db.GetAllContactsAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            RedirectToPage("/");
        }
    }

    public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            Contact contact = new(
                FirstName: FirstName,
                LastName: LastName,
                PhoneNumber: PhoneNumber,
                Birthday: Birthday);

            _db.Add(contact);
            await _db.SaveChangesAsync(cancellationToken);
            return RedirectToPage();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostDelete(int id, CancellationToken cancellationToken)
    {
        Contact? toRemove = await _db.FindAsync(id, cancellationToken);
        if (toRemove == null)
        {
            return (NotFound());
        }
        _db.Remove(toRemove);
        await _db.SaveChangesAsync(cancellationToken);
        return RedirectToAction(nameof(IndexModel));
    }
}

