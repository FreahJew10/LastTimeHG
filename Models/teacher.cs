using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class teacher:Person
    {
      public teacher() { }
        //עם id
        public teacher(int id, string firstName, string lastName, string email, string password)
            : base(id, firstName, lastName, email, password)
        {
            this.hourly_rate = 20;
            this.bio = "";
            this.isprivate = 1;
        }
        //עם id
        public teacher( int id, string firstName, string lastName, string email, string password, string bio, int hourly_rate)
            :base(id, firstName, lastName, email, password)
        {
            this.hourly_rate = hourly_rate;
            this.bio = bio;
            this.isprivate = 1;
        }

        //בלי id
        public teacher( string firstName, string lastName, string email, string password, string bio, int hourly_rate)
            : base(firstName, lastName, email, password)
        {
            this.hourly_rate = hourly_rate;
            this.bio = bio;
            this.isprivate = 1;
        }

        //בלי id
        public teacher(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {
            this.hourly_rate = 20;
            this.bio = "";
            this.isprivate = 1;
        }


        /// האם הוא מורה פרטי
        public teacher(string firstName, string lastName, string email, string password,int isprivate)
            : base(firstName, lastName, email, password)
        {
            this.hourly_rate = 20;
            this.bio = "";
            this.isprivate = isprivate;
        }
        public teacher(int id, string firstName, string lastName, string email, string password, string bio, int hourly_rate,int isprivate)
           : base(id, firstName, lastName, email, password)
        {
            this.hourly_rate = hourly_rate;
            this.bio = bio;
            this.isprivate = isprivate;
        }
        public string bio { get; set; }
        public int hourly_rate {  get; set; }
        public int isprivate {  get; set; }//האם המורה הוא מורה פרטי
        // 0 כלומר לא מורה פרטי
    }
}
