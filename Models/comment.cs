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
        //public comment(int id_of_comment, string thecomment,int studentid,int teacherid) 
        //{
        //this.id_of_comment = id_of_comment;
        //    this.thecomment = thecomment;
        //this.student_senderID = studentid;
        //    this.teacher_senderID = teacherid;
        //    this.timeopcomment=DateTime.Now;
        //}
        //public comment( string thecomment)
        //{
        //    this.thecomment = thecomment;
        //}

        //public comment(int id_of_comment, string thecomment, int student_senderID, int teacher_senderID, DateTime timeopcomment) : this(id_of_comment, thecomment, student_senderID, teacher_senderID)
        //{
        //    this.timeopcomment = timeopcomment;
        //}

        //public comment(string thecomment, int student_senderID, int teacher_senderID, DateTime timeopcomment) : this(thecomment)
        //{
        //    this.student_senderID = student_senderID;
        //    this.teacher_senderID = teacher_senderID;
        //    this.timeopcomment = timeopcomment;
        //}

        public int id_of_comment { get; set; }
        public string thecomment{ get; set; }
        public int student_senderID {  get; set; }
        public int teacher_senderID { get; set; }
        public DateTime timeopcomment { get; set; }

    }
}
