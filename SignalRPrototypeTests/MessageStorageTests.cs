using SignalRPrototype;

namespace SignalRPrototypeTests
{
    [TestClass]
    public class MessageStorageTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            MissedMessages.missedMessageList.Clear();
        }

        [TestMethod]
        public void DataAccess_SavingMessageToList_ListContainsMessage()
        {
            Message message = new Message("text", "caller", "receiver");

            MissedMessages.SaveMessage(message, new TestTextWriter());

            Assert.AreEqual(message.Text, MissedMessages.missedMessageList[0].Text);
            Assert.AreEqual(message.Caller, MissedMessages.missedMessageList[0].Caller);
            Assert.AreEqual(message.Receiver, MissedMessages.missedMessageList[0].Receiver);
            
        }

        [TestMethod]
        public void DataAccess_SavingMessageToList_WritesMessageListState()
        {
            Message message = new Message("text", "caller", "receiver");
            TestTextWriter testTextWriter = new TestTextWriter();

            MissedMessages.SaveMessage(message, testTextWriter);

            Assert.AreEqual(Environment.NewLine, testTextWriter.textList[0]);
            Assert.AreEqual($"Saving message: {message.Guid}, text", testTextWriter.textList[1]);
        }
    }

    class TestTextWriter : ITextWriter
    {
        public List<string> textList = new List<string>();

        public void WriteLine(string text)
        {
            this.textList.Add(text);
        }

        public void WriteLine()
        {
            this.textList.Add(Environment.NewLine);
        }
    }
}
