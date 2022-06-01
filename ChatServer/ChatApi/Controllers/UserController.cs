using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApi.Data;
using ChatApi.Models;
using ChatServer.Services;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;

namespace ChatApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChatApiContext _context;
        private readonly UserService _service = new UserService();

        public UserController(ChatApiContext context)
        {
            _context = context;
        }
        
        

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/contacts/{id}")]
        public IActionResult PutUser(string id, [Bind("name, server")] PUTUSER uar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Edit(id, uar.Name, uar.Server);
            return StatusCode(204);
        }



        [HttpGet("{id}/contacts")]
        public ActionResult<List<UserApiResponse>> GetContacts(string id)
        {
            var user = _service.Get(id);

            if (user is null)
            {
                return NotFound();
            }

            return _service.Get(user);
        }
        
        
        [HttpPost("{id}/contacts")]
        public IActionResult AddContact([Bind("Id, Name, Server")] UAP uap, string id)
        {

            User user = _service.Get(id);
            
            if (user is null)
            {
                return BadRequest();
            }

            User u = _service.Get(uap.Id);
            if (u is null)
            {
                return BadRequest();
            }

            u.Server = uap.Server;
            _service.Friend(u, user);
            return StatusCode(200);
            //,aybne chat
        }
        
        
        [HttpGet("{id}/contacts/{id2}")]
        public ActionResult<UserApiResponse> GetContact(string id, string id2)
        {
            var user = _service.Get(id);

            if (user is null)
            {
                return NotFound();
            }

            var u = _service.Get(id2);
            if (u is null)
            {
                return NotFound();
            }

            List<UserApiResponse> uar = _service.Get(user);
            UserApiResponse uar2 = uar.Find(x => x.Id.Equals(u.Username));
            if (uar2 is null)
            {
                return NotFound();
            }

            return uar2;
        }

        [HttpDelete("{id}/contacts/{id2}")]
        public IActionResult Unfriend(string id, string id2)
        {

            var user = _service.Get(id);

            if (user is null)
            {
                return BadRequest();
            }
            var u = _service.Get(id2);
            if (u is null)
            {
                return BadRequest();
            }
            _service.Unfriend(u, user);
            return StatusCode(204);
        }
        
        [HttpPost("add")]
        public IActionResult AddUser([Bind("Id, Password, Name, Server")] NUSER nuser)
        {

            if (ModelState.IsValid)
            {
                if (nuser.Name is null || nuser.Name.Equals(""))
                {
                    return BadRequest();
                }
                if (_service.IsPasswordValid(nuser.Password) && _service.IsNameValid(nuser.Username))
                {
                    _service.AddNewUser(new User(nuser));
                    return StatusCode(201);
                }
            }

            return StatusCode(300);
            //,aybne chat
        }
        
        
        [HttpGet("{id}/details")]
        public ActionResult<User> GetUserDetails(string id)
        {
           User u = _service.Get(id);
           return u;
        }
        
        [HttpGet("{id}/nickname")]
        public ActionResult<User> GetDetails(string id)
        {
            User u =  _service.GetDetails(id);
            if (u is null)
            {
                return NotFound();
            }

            return u;
        }
        
        [HttpGet("/{query}")]
        public ActionResult<List<Res>> GetQuery(string query)
        {
            List<Res> l = new List<Res>();
            List<User> users = _service.GetAll();
            foreach (var u in users)
            {
                if (u.Username.Contains(query))
                {
                    l.Add(new Res(u));
                }
            }

            return l;
        }
        
        [HttpPost("validate")]
        public IActionResult Validate([Bind("Id, Password, Name, Server")] NUSER nuser)
        {
            
            if (ModelState.IsValid)
            {
                if (nuser.Name is null || nuser.Name.Equals(""))
                {
                    return BadRequest();
                }

                User u = _service.Get(nuser.Username);
                if(nuser.Password == u.Password)
                {
                    return StatusCode(200);
                }
            }

            return StatusCode(300);
            //,aybne chat
        }
    }
}
