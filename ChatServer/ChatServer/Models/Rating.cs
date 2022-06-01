using System.ComponentModel.DataAnnotations;

namespace ChatServer.Models;

public class Rating
{
    public Rating(int id, string name, string text, int score) : this(id, name, text, score, DateTime.Now) {}

    public Rating(int id, string name, string text, int score, DateTime dt)
    {
        Id = id;
        Name = name;
        Text = text;
        Score = score;
        When = dt;
    }
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public int Score { get; set; }
    public DateTime When { get; set; }
}