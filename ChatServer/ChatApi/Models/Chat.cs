using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models;

public class Chat
{
    private int _nextId;
    public Chat(string id, string user1, string user2)
    {
        Id = id;
        User1 = user1;
        User2 = user2;
        Messages = new List<Message>();
    }
    [Required]
    public string Id { get; set; }
    [Required]
    public string User1 { get; set; }
    [Required]
    public string User2 { get; set; }

    public List<Message> Messages { get; set; }
    
    public void Send(string text, User sender, User receiver)
    {
        Messages.Add(new Message(++_nextId,sender.Username, text));
    }
    
    public void Send(string text, User sender, User receiver, DateTime dt)
    {
        Messages.Add(new Message(++_nextId,sender.Username, text, dt));
    }

    public void Remove(Message m)
    {
        Message w = Messages.Find(x => x.Id == m.Id);
        if (w is null)
        {
            return;
        }

        Messages.Remove(w);
    }

    public bool BelongsTo(string u1, string u2)
    {
        return (User1.Equals(u1) && User2.Equals(u2)) || (User1.Equals(u2) && User2.Equals(u1));
    }
    
    public bool BelongsTo(User u1, User u2)
    {
        return BelongsTo(u1.Username, u2.Username);
    }

    public Message getLastMessage()
    {
        if (Messages.Count == 0)
        {
            return null;
        }

        return Messages.Last();
    }
}