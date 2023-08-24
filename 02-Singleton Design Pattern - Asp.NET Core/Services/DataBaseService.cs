namespace _02_Singleton_Design_Pattern___Asp.NET_Core.Services;

public class DataBaseService
{
    private DataBaseService()
    {
        Console.WriteLine($"{nameof(DataBaseService)} is created.");
    }

    private static DataBaseService _dataBaseService;
    public static DataBaseService Instance
    {
        get
        {
            if (_dataBaseService == null)
                _dataBaseService = new DataBaseService();
            return _dataBaseService;
        }
    }
    public int Count { get; set; }

    public bool Connection()
    {
        Count++;
        Console.WriteLine("Bağlantı sağlandı ...");
        return true;
    }
    public bool DisConnection()
    {
        Console.WriteLine("Bağlantı koparıldı ...");
        return false;
    }
}
