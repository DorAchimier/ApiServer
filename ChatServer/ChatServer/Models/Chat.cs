using System.ComponentModel.DataAnnotations;

namespace ChatServer.Models;

public class Chat
{
    private int _nextId;
    public Chat(string id, User u1, User u2)
    {
        Id = id;
        User1 = u1;
        User2 = u2;
        Messages = new List<Message>();
    }
    [Required]
    public string Id { get; set; }
    public List<Message> Messages { get; set; }
    [Required]
    public User User1 { get; set; }
    [Required]
    public User User2 { get; set; }

    public void Send(string text, User sender, User receiver)
    {
        Messages.Add(new Message(++_nextId,sender, receiver, text));
    }
    
    public void Send(string text, User sender, User receiver, DateTime dt)
    {
        Messages.Add(new Message(++_nextId,sender, receiver, text, dt));
    }
}