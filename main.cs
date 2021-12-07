using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

class Program 
{
	public static async Task Main (string[] args) 
	{
		var options = new DbContextOptionsBuilder<DatabaseContext>()
			.UseInMemoryDatabase(databaseName: "Test")
			.Options;

    	var context = new DatabaseContext(options);
		CreateUsers(context);
		
		var phones = await GetPhonesAsync(context);
		Console.WriteLine($"Phones are {string.Join(", ", phones)}");
  	}

	private static void CreateUsers(DatabaseContext context)
	{
		var user1 = new User { Id = Guid.NewGuid(), Age = 18 };
		var user2 = new User { Id = Guid.NewGuid(), Age = 32 };
		var user3 = new User { Id = Guid.NewGuid(), Age = 54 };
		
		var contact1 = new Contact { Id = user1.Id, Phone = "00001"};
		var contact2 = new Contact { Id = user2.Id, Phone = "00002"};
		var contact3 = new Contact { Id = user3.Id, Phone = "00003"};

		context.Users.AddRange(user1, user2, user3);
		context.Contacts.AddRange(contact1, contact2, contact3);
		context.SaveChanges();
	}

	//надо найти список телефонов пользователей, у которых возраст больше 30
	private static Task<string[]> GetPhonesAsync(DatabaseContext context)
	{		
		return context.Users			
			.Where(x => x.Age > 30)
			.Select(x => x.Contact.Phone)
			.ToArrayAsync();
	}
}