using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
	public class Contact
	{
		[Key]
		public int ContactId { get; set; }
		[Column("FirstName", TypeName = "varchar(10)")]
		[Required]
		public string FirstName { get; set; }
		[Column("LastName", TypeName = "varchar(10)")]
		[Required]
		public string LastName { get; set; }
		[Column("Email", TypeName = "varchar(20)")]
		[Required]
		public string Email { get; set; }
		[Column("Subject", TypeName = "varchar(max)")]
		public string? Subject { get; set; }
		[Column("Massage", TypeName = "varchar(max)")]
		[Required]
		public string Massage { get; set; } = "";
	}
}
