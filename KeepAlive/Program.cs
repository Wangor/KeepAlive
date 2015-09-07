namespace KeepAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            new KeepAlive("http://coursebooking.apphb.com/", 15).Start();
            new KeepAlive("http://coursebooking.matt-b.ch/", 15).Start();
        }
    }
}
