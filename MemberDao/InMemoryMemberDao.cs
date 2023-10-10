using System;
using System.Collections.Generic;
using System.Text;

namespace MemberDao
{
    public class InMemoryMemberDao : IMemberDao
    {
        private List<Member> members = new List<Member>();

        public InMemoryMemberDao() {
            members.Add(new Member { Id = 1, Name = "Alice", Email = "alice@gmail.com", Active = true });
            members.Add(new Member { Id = 2, Name = "Bob", Email = "bob@gmail.com", Active = false });
            members.Add(new Member { Id = 3, Name = "Carol", Email = "carol@gmail.com", Active = false });
            members.Add(new Member { Id = 4, Name = "Dan", Email = "dan@gmail.com", Active = true });
        }

        public string ConnectionString { get; set; }

        public Member Add(Member member)
        {
            int maxId = members.Max(m => m.Id);

            member.Id = maxId + 1;
            members.Add(member);
            return member;
        }

        public void Close()
        {
            members.Clear();
        }

        public void Delete(int id)
        {
            int index = members.FindIndex(member => member.Id == id);
            members.RemoveAt(index);
        }

        public Member Get(int id)
        {
            Member member = members.Find(member => member.Id == id);

            if (member == null)
            {
                throw new MemberDaoException($"Member {id} not found");
            }
            return member;
        }

        public List<Member> GetAll()
        {
            return members;
        }

        public Member Update(Member memberToUpdate)
        {
            Member member = members.Find(member => member.Id == memberToUpdate.Id);

            member.Name = memberToUpdate.Name;
            member.Email = memberToUpdate.Email;
            member.Active = memberToUpdate.Active;

            return member;
        }
    }
}
