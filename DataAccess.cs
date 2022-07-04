using System.Linq;

namespace SignalRPrototype

{
    public class DataAccess
    {
        public static Dictionary<Guid, Message> messages = new Dictionary<Guid, Message>();
        
        public static void SaveMessage(Message message)
        {
            messages.Add(message.guid, message);

            Console.WriteLine();
            Console.WriteLine($"Saving message: {message.guid}, {message.text}");

            foreach (KeyValuePair<Guid, Message> kvp in messages)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                   kvp.Key, kvp.Value.text);
            }
        }

        public static void DeleteMessage(Guid guid)
        {
            Console.WriteLine();
            Console.WriteLine($"Deleting message: {guid}");

            if (!messages.ContainsKey(guid))
            {
                Console.WriteLine($"Key {guid} is not found.");
            } else
            {
                messages.Remove(guid);
            }

            foreach (KeyValuePair<Guid, Message> kvp in messages)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                   kvp.Key, kvp.Value.text);
            }
        }

        public static Message[] GetMessagesByReceiver(string receiver)
        {
            return messages.Where(message => message.Value.receiver == receiver)
                .Select(message => message.Value).ToArray();
        }
    }
}
