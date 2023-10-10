// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

Console.WriteLine("Check DB Connection");


string connString = "Server=tcp:professionaltraining.database.windows.net,1433;Initial Catalog=trainingdb;Persist Security Info=False;User ID=ptdbuser;Password=Training2023#@!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


SqlConnection conn = new SqlConnection(connString);

conn.Open();

string sql = "SELECT * FROM members";

SqlCommand cmd = new SqlCommand(sql, conn);

SqlDataReader rdr = cmd.ExecuteReader();

while (rdr.Read())
{
    int id = rdr.GetInt32(0);
    string name = rdr.GetString(1);

    Console.WriteLine($"{ id } { name }");
}

rdr.Close();
conn.Close();

