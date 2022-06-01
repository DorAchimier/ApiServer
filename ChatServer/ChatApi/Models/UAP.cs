using System.Security.Policy;

namespace ChatApi.Models;

public class UserApiResponse
{
    public UserApiResponse(string id, string name, string server, string last, DateTime lastDate)
    {
        Id = id;
        Name = name;
        Server = server;
        Last = last;
        LastDate = lastDate;
    }
    
    public UserApiResponse(string id, string name, string server)
    {
        Id = id;
        Name = name;
        Server = server;
        Last = "";
        LastDate = DateTime.Now;
    }

    public UserApiResponse(User u)
    {
        Id = u.Username;
        Name = u.Name;
        Server = u.Server;
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Server { get; set; }
    public string Last { get; set; }
    public DateTime LastDate { get; set; }
}