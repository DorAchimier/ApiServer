namespace ChatApi.Models;

public class Res
{
    public Res(User u)
    {
        Id = u.Username;
        Name = u.Name;
        Server = u.Server;
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Server { get; set; }
}