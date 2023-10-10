using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace MemberDao
{
    public class SqlMemberDao
    {
        public string ConnectionString { get; set; } = "";
        private SqlConnection conn;

        public SqlMemberDao(string connectionString)
        {
            ConnectionString = connectionString;
            conn = new SqlConnection(ConnectionString);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public Member Get(int id)
        {
            string sql = $"SELECT * FROM members WHERE id = { id }";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            Member m = null;
            if (rdr.Read())
            {
                string name = rdr.GetString(1);
                string email = rdr.GetString(2);
                bool active = rdr.GetBoolean(3);
                m = new Member {
                    Id = id,
                    Name = name,
                    Email = email,
                    Active = active
                };
            }
            rdr.Close();
            return m;
        }
        public List<Member> GetAll()
        {
            List<Member> members = new List<Member>();
            string sql = "SELECT * FROM members";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string email = rdr.GetString(2);
                bool active = rdr.GetBoolean(3);

                Member member = new Member
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Active = active
                };
                members.Add(member);
            }
            rdr.Close();
            return members;
        }
        public void Delete(int id)
        {
            string sql = $"DELETE FROM members WHERE id = {id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public Member Add(Member member)
        {
            string sql = @$"INSERT INTO members 
(name, email, active)
VALUES('{ member.Name }', '{ member.Email }', {( member.Active ? 1 : 0 )})";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            // TBD - get the id
            sql = "SELECT @@IDENTITY";

            cmd = new SqlCommand(sql, conn);

            Decimal addedId = (Decimal)cmd.ExecuteScalar();
            member.Id = (int)addedId;
            return member;
        } 
        public Member Update(Member member)
        {

            string sql = $@"
UPDATE members
SET name = '{ member.Name }',
email = '{ member.Email }',
active = {(member.Active ? 1 : 0)}
WHERE id = { member.Id }
";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            return member;
        }
    }
}
