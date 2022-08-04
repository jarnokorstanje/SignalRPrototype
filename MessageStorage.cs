namespace SignalRPrototype
{
    public static class MessageStorage //TODO betere naam, misschie nmessages
    {
        public static List<Message> messageList = new(); // private maken, je wil neit dat  iederene er bij kan, MissedMessageList van maken
        
        public static void SaveMessage(Message messageToSave, ITextWriter textWriter)
        {
            messageList.Add(messageToSave);

            textWriter.WriteLine();
            textWriter.WriteLine($"Saving message: {messageToSave.guid}, {messageToSave.text}");
        }

        public static void DeleteMessage(Guid guid, ITextWriter textWriter)
        {
            textWriter.WriteLine();
            textWriter.WriteLine($"Deleting message: {guid}");

            messageList.Remove(messageList.First(m => m.guid == guid));
        }

        public static void DeleteMultipleMessages(Guid[] guidArray, ITextWriter textWriter)
        {
            foreach (var guid in guidArray)
            {
                textWriter.WriteLine();
                textWriter.WriteLine($"Deleting missed message: {guid}");
                messageList.Remove(messageList.First(m => m.guid == guid));
            }
        }

        public static Message[] GetMessagesByReceiver(string receiver)
        {
            var missedMessages = messageList.Where(message => message.receiver == receiver).ToArray();

            return missedMessages;
        }
    }
}