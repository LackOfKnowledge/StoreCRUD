using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudDemo2.View;

namespace crudDemo2.Interfaces
{
    public interface IMenu
    {
        void AskForTask();
        void ChooseTypeOfItem();
        void CRUDChooseMenu();
        void InputDatThing(int option);
    }
}
