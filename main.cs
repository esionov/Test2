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
		foreach (var i in Enumerable.Range(0, 100))
		{
			var user = new User { Id = Guid.NewGuid(), Age = i };	
			var contact = new Contact { Id = user.Id, Phone = $"{i}"};

			context.Users.Add(user);
			context.Contacts.Add(contact);
		}
		
		context.SaveChanges();
	}

	//нужно одним запросом выбрать 10 телефонов самых старших пользователей, у которых возраст более 30
	private static Task<string[]> GetPhonesAsync(DatabaseContext context)
	{		
		throw new NotImplementedException();
	}
}