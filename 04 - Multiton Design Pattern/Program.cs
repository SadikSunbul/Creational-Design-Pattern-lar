
using System.Runtime.CompilerServices;

var msSql = Database.GetInstance("MsSql");
msSql.ConnectionString("asfsdfdhdfh");

var oracle = Database.GetInstance("Oracle","baglantı connection strings");
var mongoDb = Database.GetInstance("MongoDb");

var msSql2 = Database.GetInstance("MsSql");
var oracle2 = Database.GetInstance("Oracle");
var mongoDb2 = Database.GetInstance("MongoDb");
//Yyukarıda toplamda 3 tane nesne üretilcektir 

//burada msSql.ConnectionString==msSql2.ConnectionString true 

//3 tane data base kullanıcaz bu projede diyelim 
class Database
{
    private Database()
    { //dısarıdan erısılmesın dedık 
        Console.WriteLine($"{nameof(Database)} nesnesi üretildi");
    }

    static Dictionary<string, Database> _database = new();
    //burada mecbur methot kullanıcaz property olmaz cunku key alamayız propertyde
    public static Database GetInstance(string key)
    {
        if (!_database.ContainsKey(key))//bu key yok ise
            _database[key] = new Database();//yoksa üret 

        return _database[key];//değeri gönder
    }
    string connectionString = "";
    //Overload yaptık 
    public static Database GetInstance(string key, string conncetionString)
    {
        var database = GetInstance(key);
        //...
        database.ConnectionString(conncetionString);
        return database;
    }

    public void Connection()
    {
        Console.WriteLine("connected");
    }
    public void DisConnect()
    {
        Console.WriteLine("DisConnected");
    }
    public void ConnectionString(string connectionString)
    {
        this.connectionString = connectionString;
    }
}

