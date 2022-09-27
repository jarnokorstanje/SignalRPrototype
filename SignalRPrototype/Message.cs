namespace SignalRPrototype;
public class Message 
{
    public Guid guid { get; }
    public string text { get; }
    public string caller { get; }
    public string receiver { get; }
    public DateTime timestamp { get; }
    
    public Message(string text, string caller, string receiver)
    {
        guid = Guid.NewGuid();
        this.text = text;
        this.caller = caller;
        this.receiver = receiver;
        timestamp = DateTime.Now;
    }
}