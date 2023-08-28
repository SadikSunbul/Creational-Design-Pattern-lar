using Microsoft.Extensions.ObjectPool;

//Microsoft.Extensions.ObjectPool İnmelidir




DefaultObjectPoolProvider provider = new();
ObjectPool<X> pool = provider.Create(new DefaultPooledObjectPolicy<X>()); //object pool olusturulmasını basalattık

var x1 = pool.Get();
x1.Count++;
x1.Write();
pool.Return(x1);

var x2 = pool.Get();
x2.Count++;
x2.Write();
pool.Return(x2);


class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);

    public X()
        => Console.WriteLine("X Üretim maliyeti");

    ~X()
        => Console.WriteLine("X imha maliyeti ....");
}