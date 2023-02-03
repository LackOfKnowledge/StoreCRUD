using crudDemo2.Interfaces;

public class Menu : IMenu
{
    
    public void AskForTask()
    {
        Console.WriteLine("Wybierz akcj�");
        Console.WriteLine("1\tDodaj");
        Console.WriteLine("2\tWy�wietl");
    }

    public void ChooseTypeOfItem()
    {
        Console.WriteLine("Wybierz typ elementu");
        Console.WriteLine("1\tSmartfon");
        Console.WriteLine("2\tNotebook");
    }
    public void InputDatThing(int option)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Podaj nazw� producenta");
                    break;
                case 1:
                    Console.WriteLine("Podaj model");
                    break;
            }
        }

    public void CRUDChooseMenu()
    {
        Console.WriteLine("Wybierz CRUD");
        Console.WriteLine("1\tMongoDB");
        Console.WriteLine("2\tSQLite");
    }
}