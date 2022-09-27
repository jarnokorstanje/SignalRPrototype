namespace SignalRPrototype
{
    public static class MissedMessages
    {
        public static List<Message> missedMessageList = new();
        
        public static void SaveMessage(Message messageToSave, ITextWriter textWriter)
        {
            missedMessageList.Add(messageToSave);

            textWriter.WriteLine();
            textWriter.WriteLine($"Saving message: {messageToSave.Guid}, {messageToSave.Text}");
        }

        public static void DeleteMessages(ITextWriter textWriter, params Guid[] guidArray)
        {
            foreach (var guid in guidArray)
            {
                textWriter.WriteLine();
                textWriter.WriteLine($"Deleting missed message: {guid}");
                missedMessageList.Remove(missedMessageList.First(m => m.Guid == guid));
            }
        }

        public static Message[] GetMessagesByReceiver(string receiver)
        {
            var missedMessages = missedMessageList.Where(message => message.Receiver == receiver).ToArray();

            return missedMessages;
        }
    }
}