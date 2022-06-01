namespace Server;

public class Message
{
    int _id;
    string _text;
    User _sender;
    User _receiver;

    public Message(int id, string txt, User sender, User receiver)
    {
        _id = id;
        _text = txt;
        _sender = sender;
        _receiver = receiver;
    }
}