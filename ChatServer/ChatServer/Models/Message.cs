using System.ComponentModel.DataAnnotations;

namespace ChatServer.Models;

public class Message
{
    public Message(int id, User s, User r, string txt) : this(id, s, r, txt, DateTime.Now){}

    public Message(int id, User s, User r, string txt, DateTime dt)
    {
        Id = id;
        Sender = s;
        Receiver = r;
        Text = txt;
        When = dt;
    }
    [Required]
    public int Id { get; set; }
    [Required]
    public User Sender { get; set; }
    [Required]
    public User Receiver { get; set; }
    [Required]
    public string Text { get; set; }

    public DateTime When { get; set; }
}