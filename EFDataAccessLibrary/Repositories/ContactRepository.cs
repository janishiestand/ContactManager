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

        public void AddRange(IEnumerable<Contact> contacts)
        {
			_db.AddRange(contacts);
        }

        public async Task AddRangeAsync(IEnumerable<Contact> contacts, CancellationToken cancellationToken)
        {
			await _db.AddRangeAsync(contacts, cancellationToken);
        }


        public List<Contact> GetAllContacts()
		{
			return _db.Contacts.Include(a => a.Addresses)
            .Include(e => e.EmailAddresses)
            .ToList();
        }

        public async Task<List<Contact>> GetAllContactsAsync(CancellationToken cancellationToken)
        {
            return await _db.Contacts.Include(a => a.Addresses)
            .Include(e => e.EmailAddresses)
            .ToListAsync(cancellationToken);
        }

        public void SaveChanges()
		{
			_db.SaveChanges();
		}

		public async Task<int> CountAsync(CancellationToken cancellation)
		{
			return await _db.Contacts.CountAsync(cancellation);
		}

		public int Count()
		{
			return _db.Contacts.Count();
		}

		public async Task SaveChangesAsync(CancellationToken cancellationToken)
		{
			await _db.SaveChangesAsync(cancellationToken);
		}

		public async Task<List<Contact>> ToListAsync(CancellationToken cancellationToken)
		{
			return (await _db.Contacts.ToListAsync());
		}

		public Contact? Find(int id)
		{
			return _db.Contacts.Find(id);
		}

		public async Task<Contact?> FindAsync(int id, CancellationToken cancellationToken)
		{
			Contact? cnt = await _db.Contacts.FindAsync(id, cancellationToken);
			return cnt;
		}

    }
}

