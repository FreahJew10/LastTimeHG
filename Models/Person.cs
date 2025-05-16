namespace Models
{
    using Microsoft.AspNetCore.SignalR;
    public class Person
    {
        
        //public Person(int id, string firstName, string lastName, string  email,string password /*, byte[] picture*/,string  userid)
        //{
        //    this.Id = id;
        //    this.first_name = firstName;
        //    this.email = email;
        //    this.password = password;
        //    this.last_name = lastName;   
        //    this.userid = userid;   
        //    //this.picture = picture;
        //}
        public Person(int id, string firstName, string lastName, string email, string password /* byte[] picture*/)
        {
            this.Id = id;
            this.first_name = firstName;
            this.email = email;
            this.password = password;
            this.last_name = lastName;
            userid = "";
        }
        public Person( string firstName, string lastName, string email, string password)
        {

            this.first_name = firstName;
            this.email = email;
            this.password = password;
            this.last_name = lastName;
            // this.picture = null;
            userid = "";
        }
        public Person()
        {

        }
        public int Id { get; set; }
        public string first_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string last_name { get; set; }
     //   public byte[] picture { get; set; }
   public  string userid { get; set; }
    }
}
