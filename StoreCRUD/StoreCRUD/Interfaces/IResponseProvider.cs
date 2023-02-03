namespace crudDemo2.Interfaces
{
    public interface IResponseProvider
    {
        int GetIntFromUser(int v);
        IItem GetItemFromUser(IItem item);
        SearchArguments SearchingArgumentFromUser(IItem item);
    }
}