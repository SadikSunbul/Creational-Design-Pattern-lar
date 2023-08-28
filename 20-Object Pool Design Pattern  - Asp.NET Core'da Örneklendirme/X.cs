namespace _20_Object_Pool_Design_Pattern____Asp.NET_Core_da_Örneklendirme;

public class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);

    public X()
        => Console.WriteLine("X Üretim maliyeti");

    ~X()
        => Console.WriteLine("X imha maliyeti ....");
}
