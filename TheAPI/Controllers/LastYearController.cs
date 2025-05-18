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


        [HttpGet("{id:int}")]
        [ActionName("GETfriendlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Person>>>Get(int id)
        {
            PersonStudentDB studentDB = new PersonStudentDB();
            List<Person>friends=await studentDB.GiveAllFriends(id);
            if (friends != null)
            {
                return Ok(friends);
            }
            else return BadRequest();
        }


        [HttpPut]
        [ActionName("updatepass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody] Person person)
        {
            studentDB studentDB = new studentDB();
            if (await studentDB.updateAsync(person))
                return Ok();

            return BadRequest();
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<bool> insertStudent([FromBody]Person person)
        {
          
          studentDB studentDB =new studentDB();
            return await studentDB.insertstudent(person);

        }

        [HttpPost]
        [ActionName("eventforcalender")]
        public async Task<List<Event>> GetEventsforcalender([FromBody]ModelForAPIIDEndStartDate modelForAPIIDEndStartDate)
        {
            EventDB eventDB = new EventDB();
            return await eventDB.GetEventsForStudentInRangeForStudent(modelForAPIIDEndStartDate.studentid, modelForAPIIDEndStartDate.startdate, modelForAPIIDEndStartDate.enddate);

        }
      


       

        // DELETE api/<LastYearController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
