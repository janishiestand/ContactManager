using System;
using System.ComponentModel.DataAnnotations;

namespace EFDataAccessLibrary.Models
{
	public class Contact
	{
		public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        [MaxLength(100)]
        public string PhoneNumber { get; set; }


        [MaxLength(100)]
        public string Birthday { get; set; }

		public List<Address> Addresses { get; set; } = new List<Address>();
		public List<Email> EmailAddresses { get; set; } = new List<Email>();
    }
}

