using ChatApi.Models;
using ChatApi.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ChatApi.Services;

public class ChatService : AbstractChatService
{
    private static Dictionary<string, Chat> _context = _chats;

    public override List<Chat> GetAll()
    {
        return _context.Values.ToList();
    }

    public override Chat Get(string id)
    {
        if (_context.ContainsKey(id))
        {
            return _context[id];
        }

        return null;
    }

    public override Chat Get(string username1, string username2)
    {
        string key1 = username1 + "|" + username2;
        string key2 = username2 + "|" + username1;
        Chat c = Get(key1);
        if (c is null)
        {
            return Get(key2);
        }
        return c;
    }

    public override void Delete(string username1, string username2, int msgId)
    {
        Chat c = Get(username1, username2);
        if (c is null || c.Messages is null)
        {
            return;
        }
        
        Message m = c.Messages.Find(x => x.Id == msgId);
        if (m is null)
        {
            return;
        }
        c.Remove(m);

    }

    public override Chat GetOrMakeChat(string username1, string username2)
    {
        if (username1.Equals(username2))
        {
            return null;
        }
        Chat c = Get(username1, username2);
        if (c is null)
        {
            string key1 = username1 + "|" + username2;
            _context[key1] = new Chat(key1, username1, username2);
            User u1 = _users.Find(x => x.Username.Equals(username1));
            User u2 = _users.Find(x => x.Username.Equals(username2));
            if (u1 is null || u2 is null)
            {
                return null;
            }
            u1.AddFriend(u2);
            u2.AddFriend(u1);
            return _context[key1];
        }
        return c;
    }

    public override void Send(Chat c, string m, string s, string r)
    {
        if (c is null || m is null || s is null || r is null)
        {
            return;
        }

        User sender = _users.Find(x => x.Username.Equals(s));
        User receiver = _users.Find(x => x.Username.Equals(r));
        if (sender is null || receiver is null)
        {
            return;
        }
        if (c.BelongsTo(s, r))
        {
            c.Send(m, sender, receiver);
        }
    }

    public override Message GetMessageById(string s, string r, int id)
    {
        Chat c = Get(s, r);
        if (c is null || c.Messages is null)
        {
            return null;
        }

        return c.Messages.Find(x => x.Id.Equals(id));

    }

    public override void EditMessageById(string s, string r, int id, string m)
    {
        Message w = GetMessageById(s, r, id);
        if (m is null)
        {
            return;
        }

        w.Text = m;
    }

    public override void Send(string m, string s, string r)
    {
        Chat c = GetOrMakeChat(s, r);
        Send(c, m, s, r);
    }

}