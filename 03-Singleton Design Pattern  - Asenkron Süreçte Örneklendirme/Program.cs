


var task1 = Task.Run(() =>
{
    Example.GetIstance();
});
var task2 = Task.Run(() =>
{
    Example.GetIstance();
});

await Task.WhenAll(task1, task2); //burada 2 sınıf olusucaktır 

var task3 = Task.Run(() =>
{
    Example.GetIstance();
});
var task4 = Task.Run(() =>
{
    Example.GetIstance();
});

await Task.WhenAll(task3, task4); //burada hiç nesne oluşturulmıycaktır 

/*
 Asenkron süreçte ikiside nesne üretmeye aynı anda girmiş olabilir paralel gırmıs ıse ıkı nesne uretırebılırler
bunlardan sonrakı tetıklenmelerde nesne uretılmıycektır cunku nesneler uretılmıstı zaten 

birden fazla nesne üretilme imkanı var kesinlikler uretılır dıyemeyiz

buradaki sorunu düzelticez şimdi
lock (_obj)
        {
            if (_example == null)
                _example = new Example();
        }
kullanıcaz bu bizim için asenkron surecte ilk tetikliyen için kitlenicek onun için buradaki işlemler yapılcak
 */

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi üretildi");
    }

    private static Example _example;
    static object _obj = new object();
    public static Example GetIstance()
    {
        lock (_obj) //Asenkron için yaptık bunu 
        {
            if (_example == null)
                _example = new Example();
        }
        return _example;
    }
}

/*
 
 Aslında lock kullanmaksızında bu problemi çözebiliriz static ctor ile yapmıs olsaydık hata vermiycekti bu bize
 */