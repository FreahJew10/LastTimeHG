using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student:Person
    {
        public List<Person> friends { get; set; }
        public Student():base() { }
      
        public Student(string firstName, string lastName, string email, string password)
            :base (firstName, lastName, email, password) 
        {
            friends=new List<Person>();

        }
       

    }
}
