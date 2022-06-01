using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApi.Data;
using ChatApi.Models;
using NuGet.Packaging.Signing;
using System.Web;
using ChatApi.Services;
using ChatServer.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChatApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly ChatApiContext _context;
        private readonly ChatService _service = new ChatService();

        public ChatController(ChatApiContext context)
        {
            _context = context;
        }

        // PUT: api/Chat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/contacts/{id2}/messages")]
        public IActionResult SendMessage(string id, string id2, [Bind("content")] string message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Chat c = _service.GetOrMakeChat(id, id2);
            if (c is null)
            {
                return BadRequest();
            }

            _service.Send(c, message, id, id2);
            return StatusCode(200);
        }

        // GET: api/Chat/5
        [HttpGet("{id}/contacts/{id2}/messages")]
        public  ActionResult<Chat> GetMessages(string id, string id2)
        {
          if (_context.Chat == null)
          {
              return NotFound();
          }
          return _service.Get(id, id2);
        }
        
        
        [HttpGet("{id}/contacts/{id2}/messages/{id3}")]
        public ActionResult<Message> GetMessage(string id, string id2, int id3)
        {
            return _service.GetMessageById(id, id2, id3);
        }
        
        [HttpDelete("{id}/contacts/{id2}/messages/{id3}")]
        public IActionResult DeleteMessage(string id, string id2, int id3)
        {
            _service.Delete(id, id2, id3);
            return StatusCode(204);
        }
        
        [HttpPut("{id}/contacts/{id2}/messages/{id3}")]
        public IActionResult PutMessage(string id, string id2, int id3, [Bind("content")] string message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.EditMessageById(id, id2, id3, message);
            return StatusCode(204);
        }
        
        [HttpPost("transfer")]
        public  IActionResult TransferMsg([Bind("from, to, content")] Transfer t)
        {
            if (_context.Chat == null)
            {
                return BadRequest();
            }
            _service.Send(t.Content, t.From, t.To);
            return StatusCode(201);
        }
        
        [HttpPost("invitations")]
        public IActionResult Invite([Bind("from, to, server")] Transfer t)
        {
            if (_context.Chat == null)
            {
                return BadRequest();
            }
            _service.GetOrMakeChat(t.From, t.To);
            return StatusCode(201);
        }
    }
}
