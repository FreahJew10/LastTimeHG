using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class student:Person
    {
        public List<student> friends;
        public student() { }
        public student(int id, string firstName, string lastName, string email, string password)
            :base(id, firstName, lastName, email, password) 
        { 
         friends = new List<student>();
        
        }
        public student(int id, string firstName, string lastName, string email, string password,List<student>friends)
            :base(id, firstName, lastName, email, password)
        { this.friends = friends; }
        public student(string firstName, string lastName, string email, string password)
            :base (firstName, lastName, email, password) 
        {
            friends=new List<student>();

        }
        public student( string firstName, string lastName, string email, string password,List<student>friends)
            :base(firstName, lastName, email, password)
        {
            this.friends = friends;
        }

    }
}
