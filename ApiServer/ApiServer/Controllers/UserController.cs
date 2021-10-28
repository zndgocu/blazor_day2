using ClassExtension;
using DatabaseIManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseManager _db;
        public UserController(IDatabaseManager db)
        {
            _db = db;
        }

        // GET: api/User/test
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUsers(string id)
        {
            string qry = string.Empty;
            qry = $" SELECT id, pw" +
                  $"   FROM learn.user" +
                  $"  WHERE id = {id.Quot()}"; 
            var dbResult = _db.ExecuteQuery(qry);

            if(dbResult.IsNegative)
            {
                return NotFound();
            }
            var result = Models.User.User.GenerateUsers(dbResult.DataTable);
            if (result == null) return NotFound();
            return result;
        }
    }
}
