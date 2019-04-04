using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.Structures
{
   public class Student
    {
       public string IndexNumber  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public string Address { get; set; }
       public string Studies { get; set; }
        public override string ToString()
        {
            return $"{IndexNumber},{FirstName}, {LastName} ,{Address} ,{Studies} ";
        }

    }
}
