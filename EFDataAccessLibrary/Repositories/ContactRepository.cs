using System;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EFDataAccessLibrary.Repositories
{
	public class ContactRepository : GenericRepository<Contact>, IContactRepository
	{
		private readonly ContactContext _db;

		public ContactRepository(ContactContext db):base(db)
		{
			_db = db;
		}
		/*
        public void AddRange(IEnumerable<Contact> contacts)
        {
            _context.Set<Contact>().AddRange(contacts);
        }
		*/
        public void AddRange(IEnumerable<Contact> contacts)
        {
			_db.AddRange(contacts);
        }


        public List<Contact> GetAllContacts()
		{
			return _db.Contacts.Include(a => a.Addresses)
            .Include(e => e.EmailAddresses)
            .ToList();
        }

		public void SaveChanges()
		{
			_db.SaveChanges();
		}


		public int Count()
		{
			return _db.Contacts.Count();
		}

		public async Task SaveChangesAsync()
		{
			await _db.SaveChangesAsync();
		}

		public async Task<List<Contact>> ToListAsync()
		{
			return (await _db.Contacts.ToListAsync());
		}

		public Contact? Find(int id)
		{
			return _db.Contacts.Find(id);
		}

		public async Task<Contact> FindAsync(int id)
		{
			Contact cnt = await _db.Contacts.FindAsync(id);
			return cnt;
		}



    }
}

