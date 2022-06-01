using ChatApi.Models;
using ChatServer.Services;

namespace ChatApi.Services;

public abstract class AbstractChatService : AppService
{
    public abstract List<Chat> GetAll();

    public abstract Chat Get(string id);
    public abstract Chat Get(string username1, string username2);
    public abstract void Delete(string username1, string username2, int msgId);
    public abstract Chat GetOrMakeChat(string username1, string username2);
    public abstract void Send(Chat c, string m, string s, string r);
    public abstract void Send(string m, string s, string r);
    public abstract Message GetMessageById(string s, string r, int id);
    public abstract void EditMessageById(string s, string r, int id, string m);
}