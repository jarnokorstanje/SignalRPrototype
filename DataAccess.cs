namespace SignalRPrototype

{
    public class DataAccess
    {
        public static Dictionary<Guid, Message> missedMessages = new Dictionary<Guid, Message>();
        
        public static void SaveMessage(Message message)
        {
            missedMessages.Add(message.guid, message);

            Console.WriteLine();
            Console.WriteLine($"Saving message: {message.guid}, {message.text}");

            foreach (KeyValuePair<Guid, Message> kvp in missedMessages)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                   kvp.Key, kvp.Value.text);
            }
        }

        public static void DeleteMessage(Guid guid)
        {
            Console.WriteLine();
            Console.WriteLine($"Deleting message: {guid}");

            if (!missedMessages.ContainsKey(guid))
            {
                Console.WriteLine($"Key {guid} is not found.");
            } else
            {
                missedMessages.Remove(guid);
            }

            foreach (KeyValuePair<Guid, Message> kvp in missedMessages)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                   kvp.Key, kvp.Value.text);
            }
        }
    }
}
