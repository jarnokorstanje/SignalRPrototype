using System.Linq;

namespace SignalRPrototype

{
    public class DataAccess
    {
        public static List<Message> messageList = new List<Message>();
        
        public static void SaveMessage(Message messageToSave)
        {
            messageList.Add(messageToSave);

            Console.WriteLine();
            Console.WriteLine($"Saving message: {messageToSave.guid}, {messageToSave.text}");

            foreach (var message in messageList)
            {
                Console.WriteLine($"{message.guid}: '{message.text}' Receiver: {message.receiver}");
            }
        }

        public static void DeleteMessage(Guid guid)
        {
            Console.WriteLine();
            Console.WriteLine($"Deleting message: {guid}");

            messageList.Remove(messageList.First(m => m.guid == guid));

            foreach (var message in messageList)
            {
                Console.WriteLine($"{message.guid}: '{message.text}' Receiver: {message.receiver}");
            }
        }

        public static Message[] GetMessagesByReceiver(string receiver)
        {
            var missedMessages = messageList.Where(message => message.receiver == receiver).ToArray();

            foreach (var message in missedMessages)
            {
                messageList.Remove(messageList.First(m => m.guid == message.guid));
            }

            Console.WriteLine();
            Console.WriteLine($"Deleting missed messages for user");

            foreach (var message in messageList)
            {
                Console.WriteLine($"{message.guid}: '{message.text}' Receiver: {message.receiver}");
            }

            return missedMessages;
        }
    }
}
