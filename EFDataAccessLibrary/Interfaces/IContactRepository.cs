using System;
using System.Linq.Expressions;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Interfaces
{
	public interface IContactRepository : IGenericRepository<Contact>
	{
		List<Contact> GetAllContacts();
		void SaveChanges();
		Task SaveChangesAsync();
        int Count();
		Task<List<Contact>> ToListAsync();
		Contact? Find(int id);
		void AddRange(IEnumerable<Contact> contacts);
		Task<Contact> FindAsync(int id);

    }
}

