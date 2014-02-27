namespace KeepAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            new KeepAlive("http://www.equestriano.com", 15).Start();
        }
    }
}
