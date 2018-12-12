using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Display values, required authorization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Display value, required authorization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Inserts registration, authorization required
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Authorize]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Updates registration, authorization required
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes registration, necessary authorization
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
