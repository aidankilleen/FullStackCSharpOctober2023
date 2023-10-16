// See https://aka.ms/new-console-template for more information
using EFInvestigation;

Console.WriteLine("EF Investigation");



using (var db = new MemberDbContext("Server=tcp:professionaltraining.database.windows.net,1433;Initial Catalog=trainingdb;Persist Security Info=False;User ID=<>;Password=<>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
{
    var members = db.Members.Where(m => m.Active).OrderBy(m => m.Name).ToList();

    foreach (var member in members)
    {
        Console.WriteLine(member);
    }
}

/*


    var members = db.Members.ToList<Member>();

foreach(var member in members)
{
    Console.WriteLine(member.Name);
}


var newMember = db.Members.Add(new Member { Name = "New EF", Email = "new.ef@Gmail.com", Active = true });


Console.WriteLine(newMember);

db.SaveChanges();

Console.WriteLine(newMember);

*/
