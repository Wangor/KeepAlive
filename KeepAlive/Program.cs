namespace KeepAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            new KeepAlive("http://www.equestriano.com", 15).Start();
            new KeepAlive("http://www.handworkatelier.ch", 15).Start();
            new KeepAlive("http://www.vetkp3.ch", 15).Start();
        }
    }
}
