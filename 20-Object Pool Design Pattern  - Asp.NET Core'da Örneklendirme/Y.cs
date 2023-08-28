namespace _20_Object_Pool_Design_Pattern____Asp.NET_Core_da_Örneklendirme;

public class Y
{
    public int Index { get; set; }
    public void Write()
        => Console.WriteLine(Index);

    public Y()
        => Console.WriteLine("X Üretim maliyeti");

    ~Y()
        => Console.WriteLine("X imha maliyeti ....");
}
