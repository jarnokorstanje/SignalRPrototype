namespace SignalRPrototype
{
    public static class MissedMessages
    {
        public static List<Message> missedMessageList = new(); // private maken: hoe te voorkomen dat de test omvalt???
        
        public static void SaveMessage(Message messageToSave, ITextWriter textWriter)
        {
            missedMessageList.Add(messageToSave);

            textWriter.WriteLine();
            textWriter.WriteLine($"Saving message: {messageToSave.guid}, {messageToSave.text}");
        }

        public static void DeleteMessage(Guid guid, ITextWriter textWriter)
        {
            textWriter.WriteLine();
            textWriter.WriteLine($"Deleting message: {guid}");

            missedMessageList.Remove(missedMessageList.First(m => m.guid == guid));
        }

        public static void DeleteMultipleMessages(Guid[] guidArray, ITextWriter textWriter)
        {
            foreach (var guid in guidArray)
            {
                textWriter.WriteLine();
                textWriter.WriteLine($"Deleting missed message: {guid}");
                missedMessageList.Remove(missedMessageList.First(m => m.guid == guid));
            }
        }

        public static Message[] GetMessagesByReceiver(string receiver)
        {
            var missedMessages = missedMessageList.Where(message => message.receiver == receiver).ToArray();

            return missedMessages;
        }
    }
}