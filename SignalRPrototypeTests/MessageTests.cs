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

            Assert.AreEqual(text, message.text);
            Assert.AreEqual(caller, message.caller);
            Assert.AreEqual(receiver, message.receiver);
            Assert.AreEqual(timestamp.Year, message.timestamp.Year);
            Assert.AreEqual(timestamp.Month, message.timestamp.Month);
            Assert.AreEqual(timestamp.Day, message.timestamp.Day);
            Assert.AreEqual(timestamp.Hour, message.timestamp.Hour);
        }
    }
}