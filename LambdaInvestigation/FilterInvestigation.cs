using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LambdaInvestigation
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public override string? ToString()
        {
            return $"{Id} - {Name} - {Email} {(Active ? "Active": "Inactive")}";
        }
    }

    public class FilterInvestigation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Filtering Test");

            Member m = new Member { Id = 1, Name = "Alice", Email = "alice@gmail.com", Active = true };

            Console.WriteLine(m);

            Console.WriteLine("====================================");

            List<Member> members = new List<Member>();

            members.Add(new Member { Id = 14, Name = "Dan", Email = "dan@gmail.com", Active = true });
            members.Add(new Member { Id = 99, Name = "Alice", Email = "alice@gmail.com", Active = true });
            members.Add(new Member { Id = 18, Name = "Eve", Email = "eve@gmail.com", Active = true });
            members.Add(new Member { Id = 88, Name = "Fred", Email = "fred@gmail.com", Active = true });
            members.Add(new Member { Id = 27, Name = "Bob", Email = "bob@gmail.com", Active = false });
            members.Add(new Member { Id = 3, Name = "Carol", Email = "carol@gmail.com", Active = false });


            members.ForEach(member => Console.WriteLine(member));

            Console.WriteLine("==========================");


            List<Member> activeMembers = members.FindAll(member => member.Active);
            activeMembers.ForEach(member => Console.WriteLine(member));

            // chain them together
            members.FindAll(member => member.Active)
                    .ForEach(member => Console.WriteLine(member));

            Console.WriteLine("=================================");


            members.Sort((m1, m2) => m2.Id - m1.Id);
            
            members.ForEach(Member=>Console.WriteLine(Member));

            Console.WriteLine("=============================");

            members.Sort((m1, m2) =>
            {
                return m1.Name.CompareTo(m2.Name);
            });

            members.ForEach(member => Console.WriteLine(member));







            /*
            members.Sort((m1, m2) =>
            {
                Console.WriteLine($"Comparing {m1.Id} to {m2.Id}");

                return m1.Id - m2.Id;
                
                if (m1.Id < m2.Id)
                {
                    return -1;
                }
                else if (m1.Id == m2.Id)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
                
            });
            */

            //members.ForEach(member => Console.WriteLine(member));



            //List<Member> inactiveMembers = members.FindAll(member => !member.Active);

            //inactiveMembers.ForEach(member => Console.WriteLine(member));








        }
    }
}
