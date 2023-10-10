using MemberDao;
using System.Data.SqlClient;

Console.WriteLine("DB Hello World");

string connectionString = "Server=tcp:professionaltraining.database.windows.net,1433;Initial Catalog=trainingdb;Persist Security Info=False;User ID=<>;Password=<>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

//IMemberDao dao = new SqlMemberDao(connectionString);

IMemberDao dao = new InMemoryMemberDao();

dao.Delete(1);

Member mem2 = dao.Get(2);

mem2.Name = "CHANGED";

dao.Update(mem2);


try
{
    Member mem = dao.Get(99);

    Console.WriteLine(mem.Name);

} catch (MemberDaoException ex)
{
    Console.WriteLine(ex.Message);
}









Member newMember = new Member { 
    Name = "Aidan New2", 
    Email = "aidan.new2@gmail.com", 
    Active = true 
};

Member addedMember = dao.Add(newMember);


/*
Console.WriteLine(addedMember);
*/
/*
Member member = new Member {    
    Id = 1024, 
    Name = "CHANGED", 
    Email = "changed@gmail.com", 
    Active = false 
};

dao.Update(member);
*/
List<Member> members = dao.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
}


//Member me = dao.Get(1024);

//Console.WriteLine(me);



//int id = members.First().Id;
//dao.Delete(id);

//Console.WriteLine($"Deleted {id}");
dao.Close();



/*

SqlConnection conn = new SqlConnection(connectionString);

conn.Open();

string sql = "SELECT * FROM members";

SqlCommand cmd = new SqlCommand(sql, conn);
SqlDataReader rdr = cmd.ExecuteReader();

while(rdr.Read())
{
    int id = rdr.GetInt32(0);
    string name = rdr.GetString(1);
    string email = rdr.GetString(2);
    bool active = rdr.GetBoolean(3);

    Console.WriteLine($"{ id } { name } { email } { (active ? "Active" : "Inactive") }");
}

rdr.Close();
conn.Close();

*/

