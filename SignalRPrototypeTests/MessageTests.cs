using SignalRPrototype;

namespace SignalRPrototypeTests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void Message_MessageContructed_ValuesSet()
        {
            string text = "text";
            string caller = "caller";
            string receiver = "receiver";
            DateTime timestamp = DateTime.Now;

            Message message = new Message(text, caller, receiver);

            Assert.AreEqual(text, message.Text);
            Assert.AreEqual(caller, message.Caller);
            Assert.AreEqual(receiver, message.Receiver);
            Assert.AreEqual(timestamp.Year, message.Timestamp.Year);
            Assert.AreEqual(timestamp.Month, message.Timestamp.Month);
            Assert.AreEqual(timestamp.Day, message.Timestamp.Day);
            Assert.AreEqual(timestamp.Hour, message.Timestamp.Hour);
        }
    }
}