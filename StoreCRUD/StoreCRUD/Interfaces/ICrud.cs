public interface ICrud
{
    void AddToDataBase(IItem item);
    bool IsItExist(IItem item);
    IItem FindItem(IItem item, SearchArguments searchArguments);
}