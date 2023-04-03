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
    CancellationTokenSource cts = new CancellationTokenSource();

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
            await LoadSampleData(cancellationToken);
            var contacts = _db.GetAllContacts();
        }
        catch (Exception)
        {
            RedirectToPage("/");
        }
    }
    
    private async Task LoadSampleData(CancellationToken cancellationToken)
    {
        if (await _db.CountAsync(cancellationToken) == 0)
        {
            string file = System.IO.File.ReadAllText("sampledata.json");
            var contacts = JsonSerializer.Deserialize<List<Contact>>(file);
            await _db.AddRangeAsync(contacts, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return;
        }
            Contacts = await _db.ToListAsync(cancellationToken);
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

    public IActionResult OnPostDelete(int id, CancellationToken cancellationToken)
    {
        Contact? toRemove = _db.Find(id);
        if (toRemove == null)
        {
            return (NotFound());
        }
        _db.Remove(toRemove);
        _db.SaveChangesAsync(cancellationToken);
        return RedirectToAction(nameof(IndexModel));
    }
}

