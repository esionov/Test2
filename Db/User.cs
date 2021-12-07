using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
	[Key]
	public Guid Id { get; set; }
	public int Age { get; set; }

	public Contact Contact { get; set; }
}