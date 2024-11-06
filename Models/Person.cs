namespace Models
{
    public class Person
    {
        
        public Person(int id, string firstName, string lastName, string  email,string password /*, byte[] picture*/)
        {
            this.Id = id;
            this.first_name = firstName;
            this.email = email;
            this.password = password;
            this.last_name = lastName;
            //this.picture = picture;
        }
        //public student(int id, string firstName, string lastName, string email, string password /* byte[] picture*/)
        //{

        //    this.firstname = firstName;
        //    this.email = email;
        //    this.password = password;
        //    this.lastname = lastName;
        //}
        public Person( string firstName, string lastName, string email, string password)
        {

            this.first_name = firstName;
            this.email = email;
            this.password = password;
            this.last_name = lastName;
            // this.picture = null;
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
    }
}
