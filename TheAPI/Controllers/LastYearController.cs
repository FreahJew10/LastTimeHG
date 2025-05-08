using Microsoft.AspNetCore.Mvc;
using Models;
using DBL;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LastYearController : ControllerBase
    {
        // POST api/<ToDoListController>
        [HttpPost]
        [ActionName("login")]
        public async Task<Student> Login([FromBody] Person item)
        {
            Console.WriteLine("fsfesfsefsfsef");
            Student s = new Student();
            studentDB studentDB = new studentDB();
            s = await studentDB.LoginAsync(item.email, item.password);

            return s;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<bool> insertStudent([FromBody]Person person)
        {
          
           PersonStudentDB studentDB =new PersonStudentDB();
            return await studentDB.insertstudent(person);

        }

        [HttpPost]
        [ActionName("eventforcalender")]
        public async Task<List<Event>> GetEventsforcalender([FromBody]ModelForAPIIDEndStartDate modelForAPIIDEndStartDate)
        {
            EventDB eventDB = new EventDB();
            return await eventDB.GetEventsForStudentInRangeForStudent(modelForAPIIDEndStartDate.studentid, modelForAPIIDEndStartDate.startdate, modelForAPIIDEndStartDate.enddate);

        }
        //public async Task<Student> Login()
        //{

        //    Console.WriteLine("fsfesfsefsfsef");
        //    Student s = new Student();
        //    studentDB studentDB = new studentDB();
        //    s = await studentDB.LoginAsync("tal", "1234");

        //    return s;
        //}


        // GET: api/<LastYearController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LastYearController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LastYearController>
        [HttpPost]
        [ActionName("Test")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LastYearController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LastYearController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
