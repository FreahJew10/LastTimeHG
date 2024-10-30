using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class comment
    {
        public comment() { }
        public comment(int id_of_comment, string thecomment) 
        {
        this.id_of_comment = id_of_comment;
            this.thecomment = thecomment;
        
        }
        public comment( string thecomment)
        {
            this.thecomment = thecomment;
        }
        public int id_of_comment { get; set; }
        public string thecomment{ get; set; }


    }
}
