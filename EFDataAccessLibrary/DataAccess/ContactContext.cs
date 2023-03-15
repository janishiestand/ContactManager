using System;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.DataAccess
{
	public class ContactContext : DbContext
	{
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
		{
		}

		public DbSet<Contact> Contacts { get; set; } = default!;
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Email> EmailAddresses { get; set; }
    }
}

