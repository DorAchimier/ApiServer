namespace WebServer.Models;

public class User
{
    private static Dictionary<string, User> _users = new Dictionary<string, User>();
    string _username;
    string _name;
    string _password;
    private Dictionary<string, User> _friends;
    private Dictionary<string, Chat> _chats;

    public User(string username, string name, string password)
    {
        _username = username;
        _name = name;
        _password = password;
        _friends = new Dictionary<string, User>();
        _chats = new Dictionary<string, Chat>();
    }

    public void AddFriend(User friend)
    {
        _friends[friend.Username] = friend;  
    }
    
    public string Username
    {
        get { return _username; }
    }
    
    
}