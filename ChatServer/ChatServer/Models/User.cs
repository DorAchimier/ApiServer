using System.ComponentModel.DataAnnotations;

namespace ChatServer.Models;

public class User
{
    public User(string username, string name, string password)
    {
        Password = password;
        Username = username;
        Name = name;
        Friends = new List<User>();
    }
    [Key]
    public string Username { get; set; }
    
    [Required] 
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public List<User> Friends { get; set; }

    public void AddFriend(User u)
    {
        if (!Friends.Contains(u))
        {   
            Friends.Add(u);
        }
    }
}