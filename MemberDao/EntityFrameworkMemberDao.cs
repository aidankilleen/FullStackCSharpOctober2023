using System;
using System.Collections.Generic;
using System.Text;

namespace MemberDao
{
    public class EntityFrameworkMemberDao : IMemberDao
    {
        MemberDbContext db;
        public string ConnectionString { get; set;}

        public EntityFrameworkMemberDao(string connectionString)
        {
            ConnectionString = connectionString;
            db = new MemberDbContext(connectionString);
        }

        public List<Member> GetAll()
        {
            return db.Members.ToList();
        }



        public Member Add(Member member)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Member Get(int id)
        {
            throw new NotImplementedException();
        }



        public Member Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
