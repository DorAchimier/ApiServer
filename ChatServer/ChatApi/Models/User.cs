using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models;

public class User
{
    public User(string username, string name, string password)
    {
        Password = password;
        Username = username;
        Name = name;
        Server = "localhost:7012";
        Friends = new List<User>();
    }
    public User(string username, string name, string password, string server)
    {
        Password = password;
        Username = username;
        Name = name;
        Server = server;
        Friends = new List<User>();
    }
    
    public User(NUSER nuser)
    {
        Password = nuser.Password;
        Username = nuser.Username;
        Name = nuser.Name;
        if (nuser.Server is null || nuser.Server.Equals(""))
        {
            Server = "localhost:7012";
        }
        else
        {
            Server = nuser.Server;
        }
        Friends = new List<User>();
    }
    [Key]
    public string Username { get; set; }
    
    [Required] 
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string Server { get; set; }
    public List<User> Friends { get; set; }

    public void AddFriend(User u)
    {
        var user = Friends.Find(x => x.Username.Equals(u.Username));
        if (user is null)
        {
            Friends.Add(u);
        }
    }
    
    public void Unfriend(User u)
    {
        Friends.Remove(u);
    }
    
    
}