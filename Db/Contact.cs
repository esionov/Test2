using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contact
{
	[Key]
	public Guid Id { get; set; }
	public string Phone { get; set; }
	
	[ForeignKey(nameof(Id))]
	public User User { get; set; }
}