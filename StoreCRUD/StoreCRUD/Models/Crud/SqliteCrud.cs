using Microsoft.Data.Sqlite;

public class SqliteCrud : ICrud
{
    public static SqliteConnection _connection = new("Data Source=Data/Store.db");
    SqliteCommand _command = _connection.CreateCommand();

    public SqliteCrud()
    {
        _connection.Open();
        CreateSmartphonesTable();
        CreateNotebooksTable();
        _connection.Close();
    }
    private void CreateSmartphonesTable()
    {
        _command.CommandText = "CREATE TABLE IF NOT EXISTS smartphones (manufacturer TEXT, model TEXT)";
        _command.ExecuteNonQuery();
    }

    private void CreateNotebooksTable()
    {
        _command.CommandText = "CREATE TABLE IF NOT EXISTS notebooks (manufacturer TEXT, model TEXT)";
        _command.ExecuteNonQuery();
    }
    public void AddToDataBase(IItem item)
    {
        _connection.Open();
        if (item is Smartphone) AddSmartphoneToDatabase((Smartphone)item);
        if (item is Notebook) AddNotebookToDatabase((Notebook)item);
        _connection.Close();
    }
    private void AddSmartphoneToDatabase(Smartphone smartphone)
    {
        _connection.Open();
        _command.CommandText = @"INSERT INTO smartphones (manufacturer, model) VALUES ('{smartphone.Manufacturer}', '{smartphone.Model}')";
        _command.ExecuteNonQuery();
        _connection.Close();
    }

    private void AddNotebookToDatabase(Notebook notebook)
    {
        _connection.Open();
        _command.CommandText = @"INSERT INTO notebooks (manufacturer, model) VALUES ('{notebook.Manufacturer}', '{notebook.Model}'')";
        _command.ExecuteNonQuery();
        _connection.Close();
    }
    public bool IsItExist(IItem item)
    {
        _connection.Open();
        switch (item)
        {
            case Smartphone:
                return IsSmartphonesExist((Smartphone)item);
            case Notebook:
                return IsNotebooksExist((Notebook)item);
        }
        _connection.Close();
        return false;
    }

    private bool IsSmartphonesExist(Smartphone smartphone)
    {
        _connection.Open();
        _command.CommandText = $"SELECT COUNT(*) FROM smartphones WHERE manufacturer='{smartphone.Manufacturer}' AND model='{smartphone.Model}'";
        return (long)_command.ExecuteScalar() > 0;
        _connection.Close();
    }

    private bool IsNotebooksExist(Notebook notebook)
    {
        _connection.Open();
        _command.CommandText = $"SELECT COUNT(*) FROM notebooks WHERE manufacturer='{notebook.Manufacturer}' AND model='{notebook.Model}'";
        return (long)_command.ExecuteScalar() > 0;
        _connection.Close();
    }

    public IItem FindItem(IItem item, SearchArguments searchArguments)
    {
        _connection.Open();
        switch (item)
        {
            case Smartphone:
                return FindSmartphone(searchArguments);
            case Notebook:
                return FindNotebook(searchArguments);
        }
        _connection.Close();
        return item;
    }
    public Smartphone? FindSmartphone(SearchArguments searchArguments)
    {
        _connection.Open();
        _command.CommandText = @"select * from Smartphones where Manufacturer='" + searchArguments.Arg1 + "' and Model='" + searchArguments.Arg2 + "'";
        _command.ExecuteNonQuery();
        var user = _command.ExecuteReader();
        user.Read();
        if (!user.HasRows)
        {
            return null;
        }
        _connection.Close();
        return new Smartphone();
    }
    public Notebook? FindNotebook(SearchArguments searchArguments)
    {
        _connection.Open();
        _command.CommandText = @"select * from Notebook where Manufacturer='" + searchArguments.Arg1 + "'and Model='" + searchArguments.Arg2 + "'";
        _command.ExecuteNonQuery();
        var user = _command.ExecuteReader();
        user.Read();
        if (!user.HasRows) 
        {
            return null;
        }
        _connection.Close();
        return new Notebook();
    }
}