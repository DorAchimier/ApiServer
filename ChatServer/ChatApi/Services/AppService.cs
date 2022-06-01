using ChatApi.Models;

namespace ChatServer.Services;

public class AppService
{
    protected static List<User> _users = new List<User>
    {
        new User("a", "a", "aaaa"),
        new User("b", "as", "aasaa"),
        new User("c", "qa", "aaasa"),
        new User("d", "aw", "aaaaa"),
        new User("e", "ae", "aaadaa"),
        new User("f", "aa", "aa3aa"),
        new User("g", "ad", "aaa2a")
    };
    protected static Dictionary<string, Chat> _chats = new Dictionary<string, Chat>
    {

    };
}