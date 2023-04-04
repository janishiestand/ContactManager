using System;
using System.Linq.Expressions;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Interfaces
{
	public interface IContactRepository : IGenericRepository<Contact>
	{
		List<Contact> GetAllContacts();
		Task<List<Contact>> GetAllContactsAsync(CancellationToken cancellationToken);
        void SaveChanges();
		Task SaveChangesAsync(CancellationToken cancellationToken);
        int Count();
		Task<List<Contact>> ToListAsync(CancellationToken cancellationToken);
		Contact? Find(int id);
		void AddRange(IEnumerable<Contact> contacts);
		Task AddRangeAsync(IEnumerable<Contact> contacts, CancellationToken cancellationToken);
		Task<Contact?> FindAsync(int id, CancellationToken cancellationToken);
		Task<int> CountAsync(CancellationToken cancellationToken);

    }
}

