using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaInvestigation
{
    internal partial class Message
    {
        public override string? ToString()
        {
            return $"{Title}\n{Text}";
        }
    }
}
