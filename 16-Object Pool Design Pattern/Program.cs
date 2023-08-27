using System.Collections.Concurrent;
using System.Threading.Channels;

ObjectPool<X> pools = new();
var x = pools.Get(() => new X());//Havuzda x türünden bir nesne var ise sen bana onu getir yok ise x i üret bana gönder der
x.Count++;
pools.Return(x); //buradaki x nesnesini havuza atıyoruz

var x1 = pools.Get(() => new X()); //burada x havuzdan gelicektir 
x1.Count++;
pools.Return(x1);//bunu gene yazmalıyızki sonradan birdaha kullanmak istersek havuzda bulunsun atmaz isek artık x nesnesi kaybolucaktır 

var x2 = pools.Get(() => new X()); //burada x havuzdan gelicektir 
x2.Count++;
pools.Return(x2);//bunu gene yazmalıyızki sonradan birdaha kullanmak istersek havuzda bulunsun atmaz isek artık x nesnesi kaybolucaktır 

Console.WriteLine();
class ObjectPool<T> where T : class
{
    //bize içindeki nesneyi verir verirkende bu koleksıyondan cıkartarak verir işimiz bittiği zaman geri ekler kolaksiyona 
    readonly ConcurrentBag<T> _instances; //pool
    public ObjectPool()
    {
        _instances = new ConcurrentBag<T>();
    }

    public T Get(Func<T>? _objectGenerator = null)
    {
        //Havuzdan generik parametrede bıldırılen turdekı nesneyı geri döndürmek.


        return _instances.TryTake(out T instance) ? instance : _objectGenerator();
    }

    public void Return(T instances)
    {
        //Havuzdan ödünc alınan nesneyi iade etmek

        _instances.Add(instances);
    }
}

class X
{
    public int Count { get; set; }

    public void Write()
        => Console.WriteLine(Count);

    public X()//buralarda malıyetlı bır işlem oldugunu varsayalım
        => Console.WriteLine("X üretim maliyeti...");

    ~X()//buralarda malıyetlı bır işlem oldugunu varsayalım
        => Console.WriteLine("X imha maliyeti....");
}


