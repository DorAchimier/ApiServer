namespace Server;

public class Chat
{
    private static Dictionary<String, Chat> _chats = new Dictionary<string, Chat>();
    private string _key;
    private List<Message> _messages;

    private Chat(string key)
    {
        _key = key;
        _messages = new List<Message>();
    }

    public static Chat MakeIfAbsent(String key)
    {
        if (_chats.ContainsKey(key))
        {
            return _chats[key];
        }
        return new Chat(key);
    }
    
    public static Chat MakeIfAbsent(String un1, String un2)
    {
        String key1 = un1 + "|" + un2;
        String key2 = un2 + "|" + un1;
        if (_chats.ContainsKey(key1))
        {
            return _chats[key1];
        }
        if (_chats.ContainsKey(key2))
        {
            return _chats[key2];
        }
        Chat c = new Chat(key1);
        _chats[key1] = c;
        return c;
    }
}