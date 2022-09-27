namespace SignalRPrototype;
public class Message 
{
    public Guid Guid { get; }
    public string Text { get; }
    public string Caller { get; }
    public string Receiver { get; }
    public DateTime Timestamp { get; }
    
    public Message(string text, string caller, string receiver)
    {
        Guid = Guid.NewGuid();
        Text = text;
        Caller = caller;
        Receiver = receiver;
        Timestamp = DateTime.Now;
    }
}