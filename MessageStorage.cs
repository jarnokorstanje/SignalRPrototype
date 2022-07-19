namespace SignalRPrototype
{
    public static class MessageStorage //TODO betere naam, misschie nmessages
    {
        public static List<Message> messageList = new List<Message>(); // private maken, je wil neit dat  iederene er bij kan, MissedMessageList van maken
        
        public static void SaveMessage(Message messageToSave, ITextWriter textWriter)
        {
            messageList.Add(messageToSave);

            textWriter.WriteLine();
            textWriter.WriteLine($"Saving message: {messageToSave.guid}, {messageToSave.text}");

            foreach (var message in messageList) // todo explicit types ipv var
            {
                textWriter.WriteLine($"{message.guid}: '{message.text}' Receiver: {message.receiver}");
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

            foreach (var message in missedMessages) //todo extract to ne public function (single responsibility)
            {
                messageList.Remove(messageList.First(m => m.guid == message.guid));
            }

            Console.WriteLine();
            Console.WriteLine($"Deleting missed messages for user");

            foreach (var message in messageList)  //TODO: duplicate code, misschien message.print en in deze classe messages.printAll ofzoiets
            {
                Console.WriteLine($"{message.guid}: '{message.text}' Receiver: {message.receiver}");
            }

            return missedMessages;
        }
    }
}