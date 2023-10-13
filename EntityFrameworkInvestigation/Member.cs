using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkInvestigation
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int Balance { get; set; }

        public override string? ToString()
        {
            return $"Member:{ Id} - {Name} {Email} {( Active ? "Active" : "Inactive")}";
        }
    }
}
