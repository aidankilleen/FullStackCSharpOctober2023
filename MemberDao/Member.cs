using System;
using System.Collections.Generic;
using System.Text;

namespace MemberDao
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            return $"{ Id } { Name } { Email } { (Active ? "Active" : "Inactive" )}";
        }
    }
}
