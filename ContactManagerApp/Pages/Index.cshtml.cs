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
    private readonly ILogger<IndexModel> _logger;
    private readonly IContactRepository _db;

    public IList<Contact> Contacts = new List<Contact>();

    public IndexModel(ILogger<IndexModel> logger, IContactRepository db)
    {
        _logger = logger;
        _db = db;
    }

    public async Task OnGetAsync()
    {
        await LoadSampleData();
        var contacts = _db.GetAllContacts();
    }
    
    private async Task LoadSampleData()
    {
        if (_db.Count() == 0)
        {
            string file = System.IO.File.ReadAllText("sampledata.json");
            var contacts = JsonSerializer.Deserialize<List<Contact>>(file);
            _db.AddRange(contacts);
            _db.SaveChanges();
        }
        else
        {
            Contacts = await _db.ToListAsync();
        }
    }

    [BindProperty, Required]
    public string? FirstName { get; set; }

    [BindProperty, Required]
    public string? LastName { get; set; }

    [BindProperty, Required]
    public string? PhoneNumber { get; set; }

    [BindProperty, Required]
    public string? Birthday { get; set; }

    /* [BindProperty, Required, DisplayName("Person's Email")]
    public string? Email { get; set; }

    [BindProperty, Required, DisplayName("Person's Address")]
    public string? Address { get; set; } */

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            Contact contact = new() { FirstName = FirstName!, LastName = LastName!,
                PhoneNumber = PhoneNumber!, Birthday = Birthday! };
            _db.Add(contact);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
        return Page();
    }

    public IActionResult OnPostDelete(int id)
    {
        Contact? toRemove = _db.Find(id);
        if (toRemove == null)
        {
            return (NotFound());
        }
        _db.Remove(toRemove);
        _db.SaveChangesAsync();
        return RedirectToAction(nameof(IndexModel));
    }
}

