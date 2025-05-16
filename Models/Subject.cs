using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        //public Subject(string name,int sunjectid)
        //{
        //    subjectName = name;
        //    this.subjectid=sunjectid;
        //}
        //public Subject(string name)
        //{
        //    subjectName = name;
        //}
        public string subjectName {  get; set; }
        public int subjectid { get; set; }
        public Subject() { }
    }
}
