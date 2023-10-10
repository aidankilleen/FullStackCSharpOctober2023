using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LambdaInvestigation
{
    internal class LinqInvestigation
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Linq Investigation");

            List<Member> members = new List<Member>();

            members.Add(new Member { Id = 14, Name = "Dan", Email = "dan@gmail.com", Active = true });
            members.Add(new Member { Id = 99, Name = "Alice", Email = "alice@gmail.com", Active = true });
            members.Add(new Member { Id = 18, Name = "Eve", Email = "eve@gmail.com", Active = true });
            members.Add(new Member { Id = 88, Name = "Fred", Email = "fred@gmail.com", Active = true });
            members.Add(new Member { Id = 27, Name = "Bob", Email = "bob@gmail.com", Active = false });
            members.Add(new Member { Id = 3, Name = "Carol", Email = "carol@gmail.com", Active = false });


            

            var answer = from member in members where member.Active == false select member;


            foreach (Member m in answer)
            {
                Console.WriteLine(m);
            }





        }
    }
}
