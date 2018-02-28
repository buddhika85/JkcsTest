using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class JkcsException : Exception
    {
        public string ExcpetionMessage { get; set; }
        public DateTime ExcpetionTime { get; set; }
    }
}
