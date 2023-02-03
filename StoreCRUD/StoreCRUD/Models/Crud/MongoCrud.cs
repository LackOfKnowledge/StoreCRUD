using MongoDB.Driver;

public class MongoCrud : CrudBase, ICrud
{
    private readonly static MongoClient _client = new();
    private readonly static IMongoDatabase _database = _client.GetDatabase(_databaseName);
    private readonly IMongoCollection<Smartphone> _smartphonesCollection = _database.GetCollection<Smartphone>(_notebooksTableName);
    private readonly IMongoCollection<Notebook> _notebooksCollection = _database.GetCollection<Notebook>(_notebooksTableName);

    public void AddToDataBase(IItem item)
    {
        if (item is Smartphone)
        {
            Smartphone smartphone = (Smartphone)item;
            AddSmartphoneToDataBase(smartphone);
        }
        if (item is Notebook)
        { 
            Notebook notebook = (Notebook)item;
            AddNotebookToDataBase(notebook);
        }
    }

    private void AddNotebookToDataBase(Notebook notebook)
    {
        _notebooksCollection.InsertOne(notebook);
    }

    private void AddSmartphoneToDataBase(Smartphone smartphone)
    {
        _smartphonesCollection.InsertOne(smartphone);
    }

    public bool IsItExist(IItem item)
    {
        if (item is Smartphone) return CheckSmartphones(item);
        if (item is Notebook) return CheckNotebooks(item);
        return false;
    }

    private bool CheckNotebooks(IItem item)
    {
        Notebook notebook = (Notebook)item;
        try
        {
            var record = _notebooksCollection.Find((FilterDefinition<Notebook>?)Builders<Notebook>.Filter.And(
            Builders<Notebook>.Filter.Eq("Manufacturer", notebook.Manufacturer),
            Builders<Notebook>.Filter.Eq("Model", notebook.Model))).First();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool CheckSmartphones(IItem item)
    {
        Smartphone smartphone = (Smartphone)item;
        try
        {
            var record = _smartphonesCollection.Find((FilterDefinition<Smartphone>?)Builders<Smartphone>.Filter.And(
            Builders<Smartphone>.Filter.Eq("Manufacturer", smartphone.Manufacturer),
            Builders<Smartphone>.Filter.Eq("Model", smartphone.Model))).First();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IItem FindItem(IItem item, SearchArguments searchArguments)
    {
        return item;
    }

    private Notebook? FindNotebook(SearchArguments searchArguments)
    {
        try
        {
            return (Notebook?)_notebooksCollection.Find((FilterDefinition<Notebook>?)Builders<Notebook>.Filter.And(
    Builders<Notebook>.Filter.Eq("Manufacturer", searchArguments.Arg1),
    Builders<Notebook>.Filter.Eq("Model", searchArguments.Arg2))).First();
        }
        catch
        {
            return null;
        }
    }

    private Smartphone? FindSmartphone(SearchArguments searchArguments)
    {
        try
        {
            return (Smartphone?) _smartphonesCollection.Find((FilterDefinition<Smartphone>?)Builders<Smartphone>.Filter.And(
            Builders<Smartphone>.Filter.Eq("Manufacturer", searchArguments.Arg1),
            Builders<Smartphone>.Filter.Eq("Model", searchArguments.Arg2))).First();
        }
        catch
        {
            return null;
        }
    }
}