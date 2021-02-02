using highschool.DAL;
using highschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace highschool.Controllers.API
{
    public class DisciplineController: ApiController
    {
        // GET api/<controller>
        public IEnumerable<Discipline> Get()
        {
            return DisciplineDAL.GetDisciplines();
        }

        // GET api/<controller>/5
        public Discipline Get(int id)
        {
            return DisciplineDAL.GetDiscipline(id);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}