namespace SignalRPrototype
{
    public interface ITextWriter
    {
        void WriteLine(string text);
        void WriteLine();
    }

    public class ConsoleTextWriter: ITextWriter {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}