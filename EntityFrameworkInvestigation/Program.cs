using EntityFrameworkInvestigation;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Channels;

Console.WriteLine("Entity Framework Investigation");

var configBuilder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

var configuration = configBuilder.Build();

string? connectionString = configuration.GetConnectionString("default");

/*
using(Member m = new Member())
{


}
// the object will be disposed of here....
*/



using (var db = new MemberDbContext(connectionString))
{
    Member newMember = new Member { Name = "NEW MEMBER AIDAN", Email = "new.aidan@gmail.com", Active = true };
    db.Members.Add(newMember);
    db.SaveChanges();
    db.Members.ToList().ForEach(m => Console.WriteLine(m));

    
}
// db.Dispose(); is called implicitly because of the using 



// when we get to here the db connection is closed

/*
Member newMember = new Member { Name = "NEW MEMBER AIDAN", Email = "new.aidan@gmail.com", Active = true };

db.Members.Add(newMember);

db.SaveChanges();


db.Members.ToList().ForEach(m => Console.WriteLine(m));

Console.WriteLine("Active Members");

db.Members.Where(m => m.Active).ToList().ForEach(m => Console.WriteLine(m));
*/
/*
Console.WriteLine("Find Dan");
var dan = db.Members.First(m => m.Id == 1168);

Console.WriteLine(dan);

dan.Name = "DANNY";

db.SaveChanges();


db.Remove(dan);

db.SaveChanges();
*/

Console.WriteLine("final list");

/*
db.Members.ToList().ForEach(m => Console.WriteLine(m));
*/












