using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher:Person
    {
      public Teacher() { }
     
      


        /// האם הוא מורה פרטי
        public Teacher(string firstName, string lastName, string email, string password,int isprivate)
            : base(firstName, lastName, email, password)
        {
            this.hourly_rate = 20;
            this.bio = "";
            this.isprivate = isprivate;
        }
     
        public string bio { get; set; }
        public int hourly_rate {  get; set; }
        public int isprivate {  get; set; }//האם המורה הוא מורה פרטי
        // 0 כלומר לא מורה פרטי
    }
}
