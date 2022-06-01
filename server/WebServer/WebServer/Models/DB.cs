namespace WebServer.Models;

public class DB
{
    private Dictionary<String, User> _users = new Dictionary<string, User>();
    private Dictionary<String, Chat> _chats = new Dictionary<string, Chat>();
}