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
        //public Student(int id, string firstName, string lastName, string email, string password,  string userid)
        //    :base(id, firstName, lastName, email, password,userid) 
        //{ 
        // friends = new List<Person>();
        
        //}
        //public Student(int id, string firstName, string lastName, string email, string password,List<Person> friends)
        //    :base(id, firstName, lastName, email, password)
        //{ this.friends = friends; }
        public Student(string firstName, string lastName, string email, string password)
            :base (firstName, lastName, email, password) 
        {
            friends=new List<Person>();

        }
        //public Student( string firstName, string lastName, string email, string password,List<Person> friends)
        //    :base(firstName, lastName, email, password)
        //{
        //    this.friends = friends;
        //}

    }
}
