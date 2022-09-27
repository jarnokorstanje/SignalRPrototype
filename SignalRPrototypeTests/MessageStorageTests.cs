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

            Assert.AreEqual(message.text, MissedMessages.missedMessageList[0].text);
            Assert.AreEqual(message.caller, MissedMessages.missedMessageList[0].caller);
            Assert.AreEqual(message.receiver, MissedMessages.missedMessageList[0].receiver);
            
        }

        [TestMethod]
        public void DataAccess_SavingMessageToList_WritesMessageListState()
        {
            Message message = new Message("text", "caller", "receiver");
            TestTextWriter testTextWriter = new TestTextWriter();

            MissedMessages.SaveMessage(message, testTextWriter);

            Assert.AreEqual(Environment.NewLine, testTextWriter.textList[0]);
            Assert.AreEqual($"Saving message: {message.guid}, text", testTextWriter.textList[1]);
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
