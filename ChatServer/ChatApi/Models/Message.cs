using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models;

public class Message
{
    public Message(int id, string sender, string text) : this(id, sender, text, DateTime.Now){}

    public Message(int id, string sender, string text, DateTime when)
    {
        Id = id;
        Sender = sender;
        Text = text;
        When = when;
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string Sender { get; set; }
    [Required]
    public string Text { get; set; }

    public DateTime When { get; set; }
}