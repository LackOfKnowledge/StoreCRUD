using crudDemo2.Interfaces;

public class App
{
    private readonly IMenu _menu;
    private readonly IResponseProvider _responseProvider;
    private readonly IViewer _viewer;
    private int _response;
    private ICrud _crud;
    private IItem _item;
    private bool _doesItExist;
    private SearchArguments _searchArguments;
    public App(IMenu menu,
               IResponseProvider responseProvider,
               IViewer viewer)
    {
        _menu = menu;
        _responseProvider = responseProvider;
        _viewer = viewer;
    }
    public void Start()
    {
        _menu.CRUDChooseMenu();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:

                _crud = new MongoCrud();

                break;
            case 2:

                _crud = new SqliteCrud();
                break;
        }
        _menu.ChooseTypeOfItem();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:
                _item = new Smartphone();
                break;
            case 2:
                _item = new Notebook();
                break;
        }
        _menu.AskForTask();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:
                _item = _responseProvider.GetItemFromUser(_item);
                _doesItExist = _crud.IsItExist(_item);
                if (_doesItExist)
                {
                    _viewer.ExistingItemError();
                }
                else
                {
                    if (_viewer.OutputMsg(_item.Validate())) _crud.AddToDataBase(_item);
                }
                break;
            case 2:
                _searchArguments = _responseProvider.SearchingArgumentFromUser(_item);
                _item = _crud.FindItem(_item, _searchArguments);
                if (!_viewer.ShowItem(_item)) _viewer.NotFoundError();
                break;

        }
    }
}
