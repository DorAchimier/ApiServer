namespace Server;

public class User
{
    private static Dictionary<string, User> _users = new Dictionary<string, User>();
    string _username;
    string _name;
    string _password;
    List<User> _friends;
    private List<Chat> _chats;

    public User(string username, string name, string password)
    {
        _username = username;
        _name = name;
        _password = password;
        _friends = new List<User>();
        _chats = new List<Chat>();
    }
}