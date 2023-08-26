using System.Net.Http.Headers;
using System.Numerics;
using System.Xml;



#region Tavsıye edılmeyen kullanım 
//DataBase dataBase = new DataBase();//ürün ailesi var tek başına bir iş yapamaz

//dataBase.Type = DatabaseType.MsSql;
//dataBase.Connection = new("... connect ...");
//dataBase.Command = new();
//var result = dataBase.Connection.Connect();
//if (result == true && dataBase.Connection.state == ConnectionState.Open)
//{
//    dataBase.Command.Execute("select * from ...");
//}

//dataBase.Connection.DisConnect();
#endregion


DatabaseCreater database = new();
DataBase oracle = database.Create(new OracleDatabaseFactory());

Console.WriteLine();

enum DatabaseType
{
    Oracle,
    MsSql,
    MySql,
    PostgreSql
}
class DataBase
{
    public DataBase()
    {

    }
    public DataBase(DatabaseType type, Connection connection, Command command)
    {
        Type = type;
        Connection = connection;
        Command = command;
    }

    public DatabaseType Type { get; set; }
    public Connection Connection { get; set; }
    public Command Command { get; set; }
}
enum ConnectionState
{
    Open,
    Close
}

#region Abstract Prodcut
abstract class AbstractConnecton
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState state { get; set; }
    public abstract bool Connect();
    public abstract bool DisConnect();
}

abstract class AbstractCommand
{
    public abstract void Execute(string query);
}
#endregion


#region Concrate Product 
class Connection : AbstractConnecton
{
    string _connectionString;

    public Connection() { }
    public Connection(string connectionString)
        => _connectionString = connectionString;

    public override string ConnectionString
    {
        get => _connectionString;
        set => _connectionString = value;
    }
    public override ConnectionState state { get; set; }
    public override bool Connect()
    {
        //... işlemelr yürütülüyor
        state = ConnectionState.Open;
        return true;
    }
    public override bool DisConnect()
    {
        //... işlemler yürütülüyor
        state = ConnectionState.Close;
        return true;
    }

}

class Command : AbstractCommand, ICommand
{
    public override void Execute(string query)
    {
        //.... executing ....
    }
}
#endregion



#region Abstract Factory
abstract class DataBaseFactory
{
    public abstract AbstractConnecton CreateConnection();
    public abstract AbstractCommand CreateCommand();
}

#endregion

#region Concrate Factory
class MsSqlDatabaseFactory : DataBaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnecton CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "MsSql connection strıng";
        connection.Connect();
        return connection;
    }
}

class OracleDatabaseFactory : DataBaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnecton CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "Oracle connection strıng";
        connection.Connect();
        return connection;
    }
}
class MySqlDatabaseFactory : DataBaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnecton CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "MySql connection strıng";
        connection.Connect();
        return connection;
    }
}

class PostgrSqlDatabaseFactory : DataBaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnecton CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "PostgrSql connection strıng";
        connection.Connect();
        return connection;
    }
}
#endregion

#region Creater
class DatabaseCreater
{
    AbstractConnecton _connection;
    AbstractCommand _command;
    public DataBase Create(DataBaseFactory baseFactory)
    {
        _connection = baseFactory.CreateConnection();
        _command = baseFactory.CreateCommand();
        return new()
        {
            Command = (Command)_command,
            Connection = (Connection)_connection,
            Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), baseFactory.GetType().Name.Replace("DatabaseFactory", ""))//hangi tirde olduğunu yakalatıyoruz burada
        };

    }
}
#endregion